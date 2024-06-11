using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallGame.Components.Player.Move
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;

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
    }
}
