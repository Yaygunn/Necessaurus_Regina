using UnityEngine;

namespace Manager.StartLevel.Scrol
{
    public class StartLevel : MonoBehaviour
    {
        [SerializeField] private float _startSpeed = 20;
        private void OnEnable()
        {
            EventHub.Event_MoveSpeed += SpeedCheck;
        }

        private void OnDisable()
        {
            EventHub.Event_MoveSpeed -= SpeedCheck;
        }
        private void Start()
        {
            Time.timeScale = 1;
        }

        private void SpeedCheck(float speed)
        {
            if (speed < _startSpeed)
                return;

            EventHub.Event_MoveSpeed -= SpeedCheck;
            EventHub.StartGame();
        }
    }
}
