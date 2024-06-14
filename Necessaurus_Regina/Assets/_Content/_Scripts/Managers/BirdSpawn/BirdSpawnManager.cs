using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BallGame.Managers
{
    public class BirdSpawnManager : MonoBehaviour
    {
        [Header("Bird Prefab")]
        public GameObject BirdPrefab;
        
        [Header("Spawn Settings")]
        public float SpawnInterval = 20f;
        public int MaxSpawns = 3;
        [Tooltip("Will stop spawning birds once any bird is hit")]
        public bool StopSpawnOnKill = true;

        public Transform SpawnPoint;
        
        private int currentSpawnCount = 0;
        private bool stopSpawning = false;

        private void Start()
        {
            // Temp - will be called by the level manager once the game starts
            StartSpawning();
        }

        public void StartSpawning()
        {
            StartCoroutine(SpawnBirds());
        }

        private IEnumerator SpawnBirds()
        {
            while (currentSpawnCount < MaxSpawns && !stopSpawning)
            {
                SpawnBird();
                currentSpawnCount++;
                yield return new WaitForSeconds(SpawnInterval);
            }
        }
        
        private void SpawnBird()
        {
            Instantiate(BirdPrefab, SpawnPoint.position, Quaternion.identity);
        }
        
        public void OnBirdHit()
        {
            if (StopSpawnOnKill)
            {
                stopSpawning = true;
                
                StopCoroutine(SpawnBirds());
            }
        }

    }
}
