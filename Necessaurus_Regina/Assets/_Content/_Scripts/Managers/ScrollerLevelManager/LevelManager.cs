using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.SideScroll.Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private bool SendEndGame;
        [SerializeField] private int Score;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(SendEndGame)
            {
                SendEndGame = false;
                EventHub.PlayerEndGameScore(Score);
            }
        }
    }
}