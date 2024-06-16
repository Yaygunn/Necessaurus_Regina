using UnityEngine;

namespace Manager.StartLevel
{
    public class StartLevel : MonoBehaviour
    {
        [SerializeField] private E_Music Music;
        void Start()
        {
            PlayMusic();
        }

        private void PlayMusic()
        {
            switch (Music)
            {
                case E_Music.menu:
                    EventHub.StartMenu();
                    break;
                case E_Music.sideScroller:
                    EventHub.StartScrollerLevel();
                    break;
                case E_Music.ballGame:
                    EventHub.StartBallGameLevel();
                    break;
            }
        }
    }

    enum E_Music { menu,sideScroller, ballGame}
}