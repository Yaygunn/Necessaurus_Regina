using Audio.Events;
using Audio.FmodCommunication;
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

            _scrollerAudio.Activate();
        }

    }
    
    
}
