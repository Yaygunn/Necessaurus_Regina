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
        [Header("Ball bounce angles")] public float MinAngle = -8f;
        public float MaxAngle = 8f;

        [Header("Ball bounce forces")] public float BounceForce = 8f;
        public float HeadBounceForce = 12f;
        public float BallGravityScale = 0.8f;
        public float WallBounceUpwardForce = 0.4f;

        [Header("Ball Scoring")]
        public int PointsPerBounce = 1;

        private Rigidbody2D rb;
        private bool isFrozen = false;
        private Vector3 playerPositionAtBounce;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            SetBallGravityScale(BallGravityScale);
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
                BounceBall(other);
            }
            else if (other.CompareTag("Floor"))
            {
                EndGame();
            }
            else if (other.CompareTag("Wall") && !isFrozen)
            {
                StartCoroutine(FreezeAndBounce());
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
        private void BounceBall(Collider2D other)
        {
            Vector2 normal = CalculateNormal(other);
            float angle = Vector2.SignedAngle(Vector2.up, normal);

            Debug.Log("Hit Angle: " + angle);
            Debug.DrawLine(transform.position, transform.position + (Vector3) normal, Color.red, 5f);

            angle = Mathf.Clamp(angle, MinAngle, MaxAngle);
            normal = Quaternion.Euler(0, 0, angle) * Vector2.up;

            Debug.Log("Corrected Angle: " + angle);
            Debug.DrawLine(transform.position, transform.position + (Vector3) normal, Color.green, 5f);

            float impactBounceForce =
                (BallLevelManager.Instance.Player.GetComponent<PlayerController>().CurrentHitMove == E_HitVersions.head)
                    ? HeadBounceForce
                    : BounceForce;

            Vector3 reflectDirection = Vector2.Reflect(rb.velocity, normal);
            rb.velocity = reflectDirection.normalized * impactBounceForce;
            
            BallScoreManager.Instance.AddScore(PointsPerBounce);
        }

        /**
         * Return the normalized vector between the ball and the collided object
         */
        private Vector2 CalculateNormal(Collider2D other)
        {
            return (transform.position - other.transform.position).normalized;
        }

        /**
         * Handle the scenario when the ball hits the floor, or when the timer runs out.
         * I don't think EndGame is the best name for this method, but it will do for now.
         */
        public void EndGame()
        {
            // Probably send some event somewhere to finish the game?
            Debug.Log("EndGame");

            // For the time being, lets reset the position of the ball so we can continue testing
            ResetBallPosition();
        }

        private void ResetBallPosition()
        {
            transform.position = new Vector3(0, 8.5f, 0);
            rb.velocity = Vector2.zero;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            Vector3 minDirection = Quaternion.Euler(0, 0, MinAngle) * Vector3.up;
            Vector3 maxDirection = Quaternion.Euler(0, 0, MaxAngle) * Vector3.up;

            Gizmos.DrawLine(transform.position, transform.position + minDirection);
            Gizmos.DrawLine(transform.position, transform.position + maxDirection);
        }
    }
}