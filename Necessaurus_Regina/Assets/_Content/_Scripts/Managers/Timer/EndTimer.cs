using System.Collections;
using UnityEngine;

namespace Manager.Timer
{
    public class EndTimer : MonoBehaviour
    {
        [SerializeField] private float _endTime = 60;
        float _currentTime;
        private bool _isPlaying;
        private void OnEnable()
        {
            EventHub.Event_StartGame += OnStart;
            EventHub.Event_EndGame += OnGameEnd;
        }

        private void OnDisable()
        {
            EventHub.Event_StartGame -= OnStart;
            EventHub.Event_EndGame -= OnGameEnd;
        }

        private void OnStart()
        {
            if (_isPlaying)
                return;

            _isPlaying = true;
            StartCoroutine(EndTiming());
        }

        private void OnGameEnd()
        {
            StopAllCoroutines();
        }

        private IEnumerator EndTiming()
        {
            _currentTime = _endTime;
            while (_currentTime > 0) 
            {
                _currentTime--;
                EventHub.RemainingTime(_currentTime);
                yield return new WaitForSeconds(1);
            }
            EventHub.EndGame();
        }
    }
}