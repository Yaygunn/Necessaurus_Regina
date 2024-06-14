using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallGame
{
    public class BirdMovement : MonoBehaviour
    {
        public float FlySpeed = 2f;
        public Action OnHitCallback;
        
        private void Update()
        {
            transform.Translate(Vector2.left * FlySpeed * Time.deltaTime);
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
                OnHitCallback?.Invoke();
            }
        }
    }
}
