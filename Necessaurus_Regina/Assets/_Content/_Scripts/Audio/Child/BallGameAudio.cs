using Audio.Events;
using Audio.FmodCommunication;
using BallGame.Player.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio.BallGame
{
    public class BallGameAudio
    {
        public BallGameAudio(FModCommunication com, EventBindingSO data)
        {
            _com = com;
            _data = data;
        }

        public void Activate()
        {
            EventHub.Event_BallBirdHit += OnBirdHit;
            EventHub.Event_BallWallHit += OnWallHit;
            EventHub.Event_BallFloorHit += OnFloorHit;
            EventHub.Event_BallHitPlayer += OnBallHitPlayer;
        }

        public void DeActivate()
        {
            EventHub.Event_BallBirdHit -= OnBirdHit;
            EventHub.Event_BallWallHit -= OnWallHit;
            EventHub.Event_BallFloorHit -= OnFloorHit;
            EventHub.Event_BallHitPlayer -= OnBallHitPlayer;
        }


        private FModCommunication _com { get; }

        private EventBindingSO _data { get; }


        private void OnBirdHit()
        {
            _com.PlayOneShot(_data.BirdHit);
        }

        private void OnFloorHit()
        {
            _com.PlayOneShot(_data.FloorHit);
        }

        private void OnWallHit()
        {
            _com.PlayOneShot(_data.WallHit);
        }

        private void OnBallHitPlayer(E_HitVersions hitVersion)
        {
            _com.PlayOneShot(_data.BallKick);
        }
    }
}
