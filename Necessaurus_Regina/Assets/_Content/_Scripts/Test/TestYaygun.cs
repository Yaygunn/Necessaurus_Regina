using FMODUnity;
using SideScroller.Components.ScrollObject;
using UnityEngine;
using Manager.ObjectPool;

namespace Test.Yaygun
{
    public class TestYaygun : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        [SerializeField] GameObject prefab2;


        [SerializeField] bool spawn;
        [SerializeField] bool spawn2;

        private void Start()
        {
            Invoke("Spawnn1", 1);
            Invoke("Spawnn2", 2);
        }
        private void Update()
        {
            if(spawn)
            {
                
            }
            if (spawn2)
            {
                spawn2 = false;
                GameObject obj = ObjectPoolManager.Instance.GetObject(prefab2);
                Vector3 pos = new Vector3(17, 1, 0);
                obj.transform.position = pos;
                obj.GetComponent<ScrollObject>().SetEndLine(-5);
                obj.SetActive(true);
            }
        }

        private void Spawnn1()
        {
            Invoke("Spawnn1", 2);
            Spawn(prefab);
        }
        private void Spawnn2()
        {
            Invoke("Spawnn2", 2);
            Spawn(prefab2);
        }

        private void Spawn(GameObject prefabb)
        {
            spawn = false;
            GameObject obj = ObjectPoolManager.Instance.GetObject(prefabb);
            Vector3 pos = new Vector3(17, 0, 0);
            obj.transform.position = pos;
            obj.GetComponent<ScrollObject>().SetEndLine(-5);
            obj.SetActive(true);
        }
    }
}
