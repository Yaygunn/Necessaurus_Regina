using Unity.Mathematics;
using UnityEngine;

namespace Manager.ScrollSpeedManager
{
    public class ScrollSpeedManager : MonoBehaviour
    {
        [SerializeField] private float _playerStepSpeedIncrease;
        [SerializeField] private float _AccelerationConstant;
        [SerializeField] private float _maxSpeed;

        [SerializeField] private float _currentSpeed;
        private void OnEnable()
        {
            EventHub.Event_PlayerStep += OnPlayerStep;
        }

        private void OnDisable()
        {
            EventHub.Event_PlayerStep -= OnPlayerStep;
        }

        private void Update()
        {
            EventHub.MoveSpeed(_currentSpeed);
            _currentSpeed -= _currentSpeed * _AccelerationConstant * Time.deltaTime;
            _currentSpeed = math.clamp(_currentSpeed, 0, _maxSpeed);
        }
        private void OnPlayerStep()
        {
            _currentSpeed += _playerStepSpeedIncrease;
        }
    }
}