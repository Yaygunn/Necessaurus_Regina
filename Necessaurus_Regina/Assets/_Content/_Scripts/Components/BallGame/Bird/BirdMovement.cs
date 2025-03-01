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
        public float FlySpeed = 1.5f;
        
        public Action OnHitCallback;

        private Rigidbody2D birdRb;
        private Animator animator;

        private void Start()
        {
            birdRb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
        
        private void Update()
        {
            transform.Translate(Vector2.left * FlySpeed * Time.deltaTime);
        }

        private void KillBird()
        {
            birdRb.velocity = Vector2.zero;
            birdRb.gravityScale = 1;

            EventHub.BallBirdHit();
            BallScoreManager.Instance.AddScore("Farofa");
            animator.SetTrigger("onHit");
        }
        
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Floor"))
            {
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
