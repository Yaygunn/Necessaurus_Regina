using UnityEngine;
using Audio.FmodCommunication;
using Audio.Events;
using FMOD.Studio;

namespace Audio.Music
{
    public class MusicAudio
    {
        public MusicAudio(FModCommunication com, EventBindingSO data)
        {
            _com = com;
            _data = data;
        }

        public void Activate()
        {
            EventHub.Event_StartMenu += OnMenu;
            EventHub.Event_StartScrollerLevel += OnScrollerLevel;
            EventHub.Event_StartBallGameLevel += OnBallGameLevel;

            _com.SetInstance(ref _musicInstance, _data.Music);
        }

        public void DeActivate()
        {
            EventHub.Event_StartMenu -= OnMenu;
            EventHub.Event_StartScrollerLevel -= OnScrollerLevel;
            EventHub.Event_StartBallGameLevel -= OnBallGameLevel;

            _com.RelaeseInstance(ref _musicInstance);
        }


        private FModCommunication _com { get; }

        private EventBindingSO _data { get; }


        EventInstance _musicInstance;

        private void OnMenu()
        {
            _com.SetParameter(ref _musicInstance, "Song" , 0);
            _com.PlayInstanceIfNotPlaying(ref _musicInstance, _data.Music);
        }

        private void OnScrollerLevel()
        {
            _com.SetParameter(ref _musicInstance, "Song", 1);
        }

        private void OnBallGameLevel()
        {
            _com.SetParameter(ref _musicInstance, "Song", 2);
        }

    }
}
