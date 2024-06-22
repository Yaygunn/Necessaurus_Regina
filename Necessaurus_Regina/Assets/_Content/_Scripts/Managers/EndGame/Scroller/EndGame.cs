using UnityEngine;

namespace Manager.Scroller.Timer
{

    public class EndGame : MonoBehaviour
    {
        private bool _gameEnded;

        private void OnEnable()
        {
            EventHub.Event_EndGame += EndTheGame;
        }

        private void OnDisable()
        {
            EventHub.Event_EndGame -= EndTheGame;
        }
        private void EndTheGame()
        {
            if (_gameEnded)
                return;
            _gameEnded = true;

            print("Ended The Game");
            Time.timeScale = 0;
        }
    }
}