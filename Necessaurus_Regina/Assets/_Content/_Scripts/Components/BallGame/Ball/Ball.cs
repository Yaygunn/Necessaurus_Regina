using System;
using System.Collections;
using System.Collections.Generic;
using BallGame.Managers;
using BallGame.Player.Controller;
using UnityEngine;

namespace BallGame
{
    public class Ball : MonoBehaviour
    {
        [Header("Ball bounce angles")] public float MinAngle = -5f;
        public float MaxAngle = 5f;

        [Header("Ball bounce forces")] 
        public float BounceForce = 6f;
        public float HeadBounceForce = 10f;
        public float FeetBounceForce = 8f;
        
        public float BallGravityScale = 0.8f;
        public float WallBounceUpwardForce = 0.8f;
        
        [Header("Ball Attempts")]
        public int Attempts = 3;
        private int currentAttempts = 0;

        public Rigidbody2D rb {  get; private set; }
        private CircleCollider2D _collider;
        private Vector3 playerPositionAtBounce;
        private int consecutiveHits = 0;
        private bool isFrozen = false;
        private bool thrownBackIn = false;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CircleCollider2D>();
                
            SetBallGravityScale(0);
            
            BallLevelManager.Instance.OnLevelStart.AddListener(DropBall);
            BallLevelManager.Instance.OnLevelEnd.AddListener(FreezeBall);
        }

        private void DropBall()
        {
            _collider.enabled = true;
            SetBallGravityScale(BallGravityScale);
        }

        private void FreezeBall()
        {
            rb.velocity = Vector2.zero;
            SetBallGravityScale(0f);
            _collider.enabled = false;
        }

        /**
         * Set the gravity scale of the ball,
         * which allow it to fall faster or slower
         */
        public void SetBallGravityScale(float scale)
        {
            rb.gravityScale = scale;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                consecutiveHits++;

                if (thrownBackIn)
                {
                    BallScoreManager.Instance.AddScore("Catch me outside");
                    thrownBackIn = false;
                }
                
                // This means you can stack points for hitting the ball multiple times
                // Not sure if this is best or if we need to only trigger Tri when the ball fails on 4th hit
                if (consecutiveHits == 3)
                {
                    BallScoreManager.Instance.AddScore("Tri");
                }
                
                if (consecutiveHits == 4)
                {
                    BallScoreManager.Instance.AddScore("Tetra");
                }
                
                if (consecutiveHits == 5)
                {
                    BallScoreManager.Instance.AddScore("Penta");
                    consecutiveHits = 0;
                }
                return;
            }

            if (other.CompareTag("Floor"))
            {
                EventHub.BallFloorHit();
                thrownBackIn = false;
                consecutiveHits = 0;
                BallScoreManager.Instance.ClearActions();
                currentAttempts++;
                
                if (currentAttempts >= Attempts)
                {
                    EndGame();
                }
                else
                {
                    BallLevelManager.Instance.ResetBall();
                }
                return;
            }
            
            if (other.CompareTag("Wall") && !isFrozen)
            {
                thrownBackIn = true;
                consecutiveHits = 0;
                EventHub.BallWallHit();
                StartCoroutine(FreezeAndBounce());
                return;
            }
            
            if (other.CompareTag("Bird"))
            {
                consecutiveHits = 0;
                return;
            }
        }

        IEnumerator FreezeAndBounce()
        {
            isFrozen = true;

            // Stop the ball from sliding down the wall
            Vector2 originalVelocity = rb.velocity;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.Sleep();

            yield return new WaitForSeconds(2f);

            playerPositionAtBounce = BallLevelManager.Instance.Player.transform.position;

            rb.WakeUp();

            // Lets bounce the ball back towards the player with a slight incline and at a slower force
            Vector2 directionToPlayer = (playerPositionAtBounce - transform.position).normalized;
            directionToPlayer.y += WallBounceUpwardForce;
            rb.AddForce(directionToPlayer * (BounceForce * 0.6f), ForceMode2D.Impulse);

            isFrozen = false;
        }


        /**
         * Handles the direction and velocity of the ball
         * when it touches the player and bounces off.
         * I've included some debug lines to show the normal angle and corrected angle
         */
        public void BounceBall(Vector3 newSpeed)
        {
            rb.velocity = newSpeed;          
        }

        /**
         * Handle the scenario when the ball hits the floor, or when the timer runs out.
         * I don't think EndGame is the best name for this method, but it will do for now.
         */
        public void EndGame()
        {
            BallLevelManager.Instance.EndLevel();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            Vector3 minDirection = Quaternion.Euler(0, 0, MinAngle) * Vector3.up;
            Vector3 maxDirection = Quaternion.Euler(0, 0, MaxAngle) * Vector3.up;

            Gizmos.DrawLine(transform.position, transform.position + minDirection);
            Gizmos.DrawLine(transform.position, transform.position + maxDirection);
        }

        public void ResetBall()
        {
            rb.velocity = Vector2.zero;
            SetBallGravityScale(0);
            StartCoroutine(DelayedDrop());
        }

        private IEnumerator DelayedDrop()
        {
            yield return new WaitForSeconds(1f);
            DropBall();
        }
    }
}