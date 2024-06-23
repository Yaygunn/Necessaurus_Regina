using Unity.Mathematics;
using UnityEngine;

namespace Manager.ScrollSpeedManager
{
    enum E_Step { none, left, right }

    public class ScrollSpeedManager : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _playerStepSpeedIncrease;
        [SerializeField] private float _runAccelerationConstant;
        [SerializeField] private float _maxSpeed;

        [SerializeField] private float _currentSpeed;

        [Header("Jump")]
        [SerializeField] private float _minJumpSpeed;
        [SerializeField] private float _jumpSpeedLost;
        [SerializeField] private float _jumpAcceleration;

        [Header("Crouch")]
        [SerializeField] private float _minCrouchSpeed;
        [SerializeField] private float _crouchSpeedLost;
        [SerializeField] private float _crouchAcceleration;

        [Header("Damage")]
        [SerializeField] private float _damageSpeedLost;
        [SerializeField] private float _damageAcceleration;

        private float _accelerationConstant;

        private E_Step LegState;

        private void Start()
        {
            _accelerationConstant = _runAccelerationConstant;
        }
        private void Update()
        {
            _currentSpeed -= _currentSpeed * _accelerationConstant * Time.deltaTime;
            _currentSpeed = math.clamp(_currentSpeed, 0, _maxSpeed);
            EventHub.MoveSpeed(_currentSpeed);
            EventHub.MoveSpeedRate(_currentSpeed / _maxSpeed);
            _animator.SetFloat("Speed", _currentSpeed);
        }
        private void OnPlayerStep()
        {
            _currentSpeed += _playerStepSpeedIncrease;
        }

        private void PlayerHalfStep()
        {
            _currentSpeed += _playerStepSpeedIncrease * 0.4f;
        }

        public void RightStep()
        {
            if( LegState == E_Step.right )
            {
                PlayerHalfStep();
            }
            else
            {
                OnPlayerStep();
            }
            LegState = E_Step.right;
        }
        public void LeftStep()
        {
            if( LegState == E_Step.left)
            {
                return;
            }
            else
            {
                OnPlayerStep();
                LegState = E_Step.left;
            }
        }

        public void Crouch()
        {
            _currentSpeed = math.max(_currentSpeed - _crouchSpeedLost, _minCrouchSpeed);
            _accelerationConstant = _crouchAcceleration;
        }
            public void Jump()
        {
            _currentSpeed = math.max(_currentSpeed - _jumpSpeedLost, _minJumpSpeed);
            _accelerationConstant = _jumpAcceleration;
        }

        public void IdleMod()
        {
            _accelerationConstant = _runAccelerationConstant;
            LegState = E_Step.none;
        }

        public void DamageMod()
        {
            _currentSpeed = math.max(0, _currentSpeed - _damageSpeedLost);
            _accelerationConstant = _damageAcceleration;
        }
    }
}