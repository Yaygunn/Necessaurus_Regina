using UnityEngine;
using System;
using Manager.ObjectPool;

namespace Scriptable.BackGroundHolder
{
    [CreateAssetMenu(fileName = "BackGround", menuName = "Scriptables/BackGround")]
    public class BackGroundHolder : ScriptableObject
    {
        [SerializeField] S_Background[] S_Background;

        public GameObject GetRandomObject()
        {
            float randomNumber = GetRandomNumber();

            for (int i = 0; i < S_Background.Length; i++)
            {
                randomNumber -= S_Background[i]._spawnRate;

                if (randomNumber <= 0)
                {
                    GameObject obj = ObjectPoolManager.Instance.GetObject(S_Background[i]._prefab);
                    obj.transform.position = new Vector3(25, S_Background[i].GetRandomY(), 0);
                    return obj;
                }
            }
            return null;
        }

        private float GetRandomNumber()
        {
            float sum = 0;
            foreach (S_Background obstacle in S_Background)
            {
                sum += obstacle._spawnRate;
            }
            return UnityEngine.Random.Range(0, sum);
        }
    }

    [Serializable]
    public struct S_Background
    {
        [field: SerializeField] public GameObject _prefab { get; private set; }
        [field: SerializeField] public float _spawnRate { get; private set; }
        [SerializeField] private float _minY;
        [SerializeField] private float _maxY;
        public float GetRandomY()
        {
            return UnityEngine.Random.Range(_minY, _maxY);
        }
    }
}
