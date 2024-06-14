using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallGame.Managers
{
    public class BallLevelManager : MonoBehaviour
    {
        public static BallLevelManager Instance { get; private set; }
        public GameObject Player { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                InitalizeReferences();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void InitalizeReferences()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            
            if (Player == null)
            {
                Debug.LogError("Player object not found in the scene. Please ensure the player object is tagged correctly.");
            }
        }
    }   
}
