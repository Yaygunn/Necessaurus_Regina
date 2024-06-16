using Audio.Events;
using Audio.FmodCommunication;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio.BallGame
{
    public class BallGameAudio : MonoBehaviour
    {
        public BallGameAudio(FModCommunication com, EventBindingSO data)
        {
            _com = com;
            _data = data;
        }

        public void Activate()
        {
            EventHub.Event_BallBirdHit += OnBirdHit;
            Debug.Log("Activated");
        }

        public void DeActivate()
        {
            EventHub.Event_BallBirdHit -= OnBirdHit;
        }


        private FModCommunication _com { get; }

        private EventBindingSO _data { get; }


        private void OnBirdHit()
        {
            _com.PlayOneShot(_data.BirdHit);
            Debug.Log("BirdHit");
        }
    }
}
