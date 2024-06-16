using Audio.Events;
using Audio.FmodCommunication;
using UnityEngine;

namespace Manager.Audio
{

    public class AudioManager : MonoBehaviour
    {
        private static AudioManager instance;

        [SerializeField] private EventBindingSO _eventBindingSO;

        private FmodCommunication _fmodCommunication;

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
            _fmodCommunication = new FmodCommunication();

            _scrollerAudio = new ScrollerAudio(_fmodCommunication, _eventBindingSO);

            _scrollerAudio.Activate();
        }

    }
    
    
}
