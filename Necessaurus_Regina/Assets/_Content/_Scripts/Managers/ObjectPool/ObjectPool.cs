using System.Collections.Generic;
using Component.PoolObject;
using UnityEngine;

namespace Manager.ObjectPool
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance { get; private set; }

        private Dictionary<GameObject, Queue<GameObject>> _poolDictionary;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                _poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Initialize the pool with a list of prefabs and an initial size for each
        public void InitializePool(List<GameObject> prefabs, int initialSize)
        {
            foreach (var prefab in prefabs)
            {
                if (!_poolDictionary.ContainsKey(prefab))
                {
                    _poolDictionary[prefab] = new Queue<GameObject>();

                    for (int i = 0; i < initialSize; i++)
                    {
                        GameObject obj = Instantiate(prefab);
                        obj.SetActive(false);
                        _poolDictionary[prefab].Enqueue(obj);
                    }
                }
            }
        }

        // Get an object from the pool
        public GameObject GetObject(GameObject prefab)
        {
            GameObject obj;
            if (_poolDictionary.ContainsKey(prefab))
            {
                if (_poolDictionary[prefab].Count > 0)
                {
                    obj = _poolDictionary[prefab].Dequeue();
                    obj.SetActive(true);
                }
                else
                {
                    obj = Instantiate(prefab);
                }
            }
            else
            {
                _poolDictionary[prefab] = new Queue<GameObject>();
                obj = Instantiate(prefab);
                obj.SetActive(false);
            }

            obj.GetComponent<PoolObject>().SetReturnDependencies(prefab, ReturnObject);
            return obj;
        }

        // Return an object to the pool
        private void ReturnObject(GameObject prefab, GameObject obj)
        {
            if (_poolDictionary.ContainsKey(prefab))
            {
                obj.SetActive(false);
                _poolDictionary[prefab].Enqueue(obj);
            }
            else
            {
                print("Returned object is not part of the dictionary");
                Destroy(obj);
            }
        }
    }
}