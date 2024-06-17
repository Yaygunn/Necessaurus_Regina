using System;
using System.Collections;
using System.Collections.Generic;
using BallGame.UI;
using UnityEngine;
using UnityEngine.Events;

namespace BallGame.Managers
{
    public class BallLevelManager : MonoBehaviour
    {
        public static BallLevelManager Instance { get; private set; }
        public GameObject Player { get; private set; }

        public bool GameHasStarted;
        public bool GameHasEnded;
        
        [Header("Level Timer")]
        public float LevelTime = 90f;
        public UnityEvent OnLevelStart;
        public UnityEvent OnLevelEnd;

        [Header("Ball")] public GameObject Ball;
        public Transform BallSpawnPoint;
        
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
            Time.timeScale = 1;
        }
        
        private void InitalizeReferences()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            
            if (Player == null)
            {
                Debug.LogError("Player object not found in the scene. Please ensure the player object is tagged correctly.");
            }
        }

        public void StartLevel()
        {
            StartCoroutine(LevelStartCoroutine());
        }

        private IEnumerator LevelStartCoroutine()
        {
            GameHasStarted = true;
            
            timeRemaining = LevelTime;
            
            yield return StartCoroutine(BallGameUI.Instance.CountdownCoroutine());
            
            BallGameUI.Instance.SetTimer(timeRemaining);
            
            // Invoke level start event (used for spawning ball + unlocking player movement)
            SpawnBall();
            
            OnLevelStart?.Invoke();
        }

        private void SpawnBall()
        {
            Instantiate(Ball, BallSpawnPoint.position, Quaternion.identity);
        }
        
        public void EndLevel()
        {
            GameHasEnded = true;
            
            OnLevelEnd?.Invoke();

            Time.timeScale = 0;
        }
    }   
}
