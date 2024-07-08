using Audio.BallGame;
using Audio.Events;
using Audio.FmodCommunication;
using Audio.Music;
using Audio.Scroller;
using UnityEngine;

namespace Manager.Audio
{

    public class AudioManager : MonoBehaviour
    {
        private static AudioManager instance;

        [SerializeField] private EventBindingSO _eventBindingSO;

        private FModCommunication _fmodCommunication;

        private ScrollerAudio _scrollerAudio;

        private BallGameAudio _ballGameAudio;

        private MusicAudio _musicAudio;
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;


                Initializeeee();
            }
        }

        private void Initializeeee()
        {
            _fmodCommunication = new FModCommunication();

            _scrollerAudio = new ScrollerAudio(_fmodCommunication, _eventBindingSO);

            _ballGameAudio = new BallGameAudio(_fmodCommunication, _eventBindingSO);

            _musicAudio = new MusicAudio(_fmodCommunication, _eventBindingSO);

            EventHub.Event_StartBallGameLevel += OpenBallGame;
            EventHub.Event_StartScrollerLevel += OpenScrollGame;

            _musicAudio.Activate();
        }

        private void OpenBallGame()
        {
            _scrollerAudio.DeActivate();
            _ballGameAudio.Activate();
        }
        private void OpenScrollGame()
        {
            _scrollerAudio.Activate();
            _ballGameAudio.DeActivate();
        }
    }
    
    
}
