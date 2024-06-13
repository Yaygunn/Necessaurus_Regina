using Manager.ObjectPool;
using System;
using UnityEngine;

namespace Manager.SideScroll.Spawner
{
    [CreateAssetMenu(fileName = "Obstacles", menuName = "Scriptables/Obstacles")]
    public class ObstaclesData : ScriptableObject
    {
        [SerializeField] S_Obstacle[] obstacles;

        public GameObject GetRandomObject()
        {
            float randomNumber = GetRandomNumber();
  
            for(int i = 0; i < obstacles.Length; i++)
            {
                randomNumber -= obstacles[i]._weightForRandomSelection;

                if (randomNumber <= 0)             
                    return ObjectPoolManager.Instance.GetObject(obstacles[i]._prefab);
            }
            return null;
        }

        private float GetRandomNumber()
        {
            float sum = 0;
            foreach(S_Obstacle obstacle in obstacles)
            {
                sum += obstacle._weightForRandomSelection;
            }
            return UnityEngine.Random.Range(0, sum);
        }
    }

    [Serializable]
    struct S_Obstacle
    {
        [field:SerializeField] public GameObject _prefab {  get; private set; }

        [field:SerializeField] public float _weightForRandomSelection { get; private set; }
    }

    
}
