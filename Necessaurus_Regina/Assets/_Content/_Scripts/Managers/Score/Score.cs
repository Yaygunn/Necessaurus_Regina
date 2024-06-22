using UnityEngine;

namespace Manager.Scroller.Score
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private float _moveMultiplyConstanr = 1;
        [SerializeField] private float _score;
        private void OnEnable()
        {
            EventHub.Event_MoveSpeed += OnMove;
        }

        private void OnDisable()
        {
            EventHub.Event_MoveSpeed -= OnMove;
        }

        private void OnMove(float move)
        {
            _score += move * _moveMultiplyConstanr * Time.deltaTime;
            EventHub.PlayerScore(GetScore());
        }

        public int GetScore()
        {
            return (int) _score;
        }

    }
}
