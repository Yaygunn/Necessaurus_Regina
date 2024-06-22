using UnityEngine;
using Audio.FmodCommunication;
using Audio.Events;
using Component.ObstacleType;

namespace Audio.Scroller
{
    public class ScrollerAudio
    {
        public ScrollerAudio(FModCommunication com, EventBindingSO data)
        {
            _com = com;
            _data = data;
        }

        public void Activate()
        {
            EventHub.Event_PlayerJump += OnJumped;
            EventHub.Event_PlayerCollided += Collided;
        }

        public void DeActivate()
        {
            EventHub.Event_PlayerJump -= OnJumped;
            EventHub.Event_PlayerCollided -= Collided;
        }


        private FModCommunication _com { get; }

        private EventBindingSO _data { get; }


        private void OnJumped()
        {
            _com.PlayOneShot(_data.Jump);
        }

        private void Collided(EObsType type)
        {
            switch (type)
            {
                case EObsType.Dog:
                    _com.PlayOneShot(_data.DogHit);
                    break;
                case EObsType.FlipFlop:
                    _com.PlayOneShot(_data.FlipFlopHit);
                    break;
                case EObsType.Chair:
                    _com.PlayOneShot(_data.ChairHit);
                    break;
            }
        }
    }
}
