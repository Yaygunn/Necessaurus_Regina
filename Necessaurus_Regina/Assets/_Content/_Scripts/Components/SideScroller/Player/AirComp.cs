using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace SideScroller.Components.Jump
{
    public class AirComp : MonoBehaviour
    {
        private Action _jumpEnd;
        private Action _tick;
        private float _speedCurrent;
        [Header("GrondCheck")]
        [SerializeField] private LayerMask _groundLayers;
        [SerializeField] private Transform _groundCheckPosition;
        [SerializeField] private float _groundCheckRayLength;
        [Header("Ascent")]
        [SerializeField] private float _speedAtJumpStart;
        [SerializeField] private float _accelerationAscent;
        [SerializeField] private float _ascentEndSpeed;
        [Header("Peak")]
        [SerializeField] private float _accelerationPeak;
        [SerializeField] private float _peakEndSpeed;
        [Header("Descent")]
        [SerializeField] private float _accelerationDescent;
        [SerializeField] private float _DescentMinSpeed;
        [Header("Fall")]
        [SerializeField] private float _accelerationFall;
        [SerializeField] private float _FallMaxSpeed;

        private float _startY;

        private void Start()
        {
            _startY = transform.position.y;
        }
        public void StartJump(Action jumpEnd)
        {
            _jumpEnd = jumpEnd;
            if (IsOnGround())
            {
                _speedCurrent = _speedAtJumpStart;
                _tick = AscentTick;
                EventHub.PlayerJump();
            }
            else
            {
                print("Trying to jump but not on the ground");
            }
        }

        public void JumpTick()
        {
            _tick();
        }

        public void JumpEnd()
        {
            _jumpEnd();
        }

        private void AscentTick()
        {
            JumpMovement(_accelerationAscent);
            if(_speedCurrent <= _ascentEndSpeed)
            {
                _speedCurrent = _ascentEndSpeed;
                StartPeakTick();
            }
        }

        private void StartPeakTick()
        {
            _tick = PeakTick;
        }
        private void PeakTick()
        {
            JumpMovement(_accelerationPeak);
            if (_speedCurrent <= _peakEndSpeed)
            {
                _speedCurrent = _peakEndSpeed;
                StartDescentTick();
            }
        }

        private void StartDescentTick()
        {
            _tick = DescentTick;
        }
        private void DescentTick()
        {
            JumpMovement(_accelerationDescent);
            if (IsOnGround())
            {
                SetPositionToGround();
                JumpEnd();
            }
            if(_speedCurrent < _DescentMinSpeed)
                _speedCurrent = _DescentMinSpeed;
        }
        private void JumpMovement(float acceleration)
        {
            Vector3 pos = transform.position;
            pos.y += _speedCurrent * Time.deltaTime;
            transform.position = pos;
            _speedCurrent += acceleration * Time.deltaTime;
        }

        private bool IsOnGround()
        {
            return transform.position.y <= _startY;
        }

        private void SetPositionToGround()
        {
            Vector3 pos = transform.position;
            pos.y = _startY;
            transform.position = pos;
        }

        public void OnDamage()
        {
            StartCoroutine(DamageFall());
        }

        private IEnumerator DamageFall()
        {
            _speedCurrent = math.min(_speedCurrent, _FallMaxSpeed);
            while(!IsOnGround())
            {
                FallMovement();
                yield return null;
            }
            SetPositionToGround() ;
        }

        private void FallMovement()
        {
            JumpMovement(_accelerationFall);
        }
    }
}
