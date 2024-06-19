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

        public float SpawnAfter = 10f;
        public int MaxSpawns = 3;
        [Tooltip("Will stop spawning birds once any bird is hit")]
        public bool StopSpawnOnKill = true;

        public Transform SpawnPoint;
        
        private int currentSpawnCount = 0;
        private bool stopSpawning = false;

        private void Start()
        {
            BallLevelManager.Instance.OnLevelStart.AddListener(StartSpawning);
            BallLevelManager.Instance.OnLevelEnd.AddListener(StopSpawning);
        }
        
        private void OnDisable()
        {
            BallLevelManager.Instance.OnLevelStart.RemoveListener(StartSpawning);
            BallLevelManager.Instance.OnLevelEnd.RemoveListener(StopSpawning);
        }

        public void StartSpawning()
        {
            StartCoroutine(SpawnBirds());
        }

        private IEnumerator SpawnBirds()
        {
            yield return new WaitForSeconds(SpawnAfter);
            
            while (currentSpawnCount < MaxSpawns && !stopSpawning)
            {
                SpawnBird();
                currentSpawnCount++;
                yield return new WaitForSeconds(SpawnInterval);
            }
        }
        
        private void SpawnBird()
        {
            GameObject newBird = Instantiate(BirdPrefab, SpawnPoint.position, Quaternion.identity);
            BirdMovement birdFall = newBird.GetComponent<BirdMovement>();
            birdFall.OnHitCallback = OnBirdHit;
        }
        
        public void OnBirdHit()
        {
            if (StopSpawnOnKill)
            {
                StopSpawning();
            }
        }

        public void StopSpawning()
        {
            stopSpawning = true;
                
            StopCoroutine(SpawnBirds());
        }
    }
}
