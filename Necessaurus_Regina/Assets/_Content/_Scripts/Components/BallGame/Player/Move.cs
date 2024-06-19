using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallGame.Components.Player.Move
{
    public class Move : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        
        [Header("Boundries")]
        [SerializeField] private float leftBoundary = -10f;
        [SerializeField] private float rightBoundary = 10f;

        private Rigidbody2D rb;

        private float _targetSpeed;

        private float _speed;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            SpeedChange();

            rb.velocity = new Vector3(_speed, 0, 0);

            ClampPosition();
        }
        
        public void GetMoveInput(float input)
        {
            _targetSpeed = input * _maxSpeed;
        }

        private void SpeedChange()
        {
            if (_targetSpeed > _speed)
            {
                _speed = Mathf.Min(_speed + _acceleration * Time.deltaTime, _targetSpeed);
            }
            else if (_targetSpeed < _speed)
            {
                _speed = Mathf.Max(_speed - _acceleration * Time.deltaTime, _targetSpeed);
            }
        }
        
        private void ClampPosition()
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftBoundary, rightBoundary);
            transform.position = clampedPosition;
        }
    }
}
