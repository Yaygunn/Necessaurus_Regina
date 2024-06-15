using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BallGame.Managers
{
    public class BallLevelManager : MonoBehaviour
    {
        public static BallLevelManager Instance { get; private set; }
        public GameObject Player { get; private set; }
        
        [Header("Level Timer")]
        public float LevelTime = 90f;
        public UnityEvent OnLevelStart;
        public UnityEvent OnLevelEnd;
        
        private float timeRemaining;

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

        private void Start()
        {
            // To be trigger with a button later
            StartLevel();
        }

        private void Update()
        {
            UpdateLevelTimer();
        }
        
        private void InitalizeReferences()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            
            if (Player == null)
            {
                Debug.LogError("Player object not found in the scene. Please ensure the player object is tagged correctly.");
            }
        }

        private void StartLevel()
        {
            timeRemaining = LevelTime;
            
            OnLevelStart?.Invoke();
        }

        private void UpdateLevelTimer()
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                
                if (timeRemaining <= 0)
                {
                    timeRemaining = 0;
                    EndLevel();
                }
            }
        }
        
        public float GetTimeRemaining()
        {
            return timeRemaining;
        }
        
        private void EndLevel()
        {
            OnLevelEnd?.Invoke();
            
            Debug.Log("Level Ended!");
        }
    }   
}
