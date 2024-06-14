using System;
using System.Collections;
using System.Collections.Generic;
using BallGame.Managers;
using UnityEngine;

namespace BallGame
{
    public class BirdMovement : MonoBehaviour
    {
        [Header("Bird Movement")]
        public float FlySpeed = 2f;

        [Header("Bird Scoring")]
        public int PointsForHit = 10;
        
        public Action OnHitCallback;

        private Rigidbody2D birdRb;

        private void Start()
        {
            birdRb = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            transform.Translate(Vector2.left * FlySpeed * Time.deltaTime);
        }

        private void KillBird()
        {
            birdRb.velocity = Vector2.zero;
            birdRb.gravityScale = 1;
            
            BallScoreManager.Instance.AddScore(PointsForHit);
        }
        
        private void OnBecameInvisible()
        {
            Debug.Log("Bird is out of view");
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Floor"))
            {
                Debug.Log("Bird has hit the floor");
                Destroy(gameObject);
            }
            else if (other.CompareTag("Ball"))
            {
                KillBird();
                
                OnHitCallback?.Invoke();
            }
        }
    }
}
