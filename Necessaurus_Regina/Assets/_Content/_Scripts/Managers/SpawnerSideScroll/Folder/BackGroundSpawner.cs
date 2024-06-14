using Manager.ObjectPool;
using SideScroller.Components.ScrollObject;
using UnityEngine;

namespace Manager.SideScroll.Spawner.BackGround
{
    public class BackGroundSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabBackGround;

        [SerializeField] private float _DistanceBetweenSpawns;

        [Header("Positions")]
        [SerializeField] private float _spawnX;
        [SerializeField] private float _destroyX;

        private float _distanceSinceLastSpawn;

        private void OnEnable()
        {
            EventHub.Event_MoveSpeed += OnMove;
        }
        private void OnDisable()
        {
            EventHub.Event_MoveSpeed -= OnMove;
        }

        private void OnMove(float x)
        {
            _distanceSinceLastSpawn += x * Time.deltaTime;
            if (_distanceSinceLastSpawn >= _DistanceBetweenSpawns)
            {
                _distanceSinceLastSpawn -= _DistanceBetweenSpawns;
                Spawn(_spawnX);
            }
        }
        private void Spawn(float x)
        {
            GameObject obj = ObjectPoolManager.Instance.GetObject(_prefabBackGround);
            Vector3 pos = new Vector3(x, 5, 0);
            obj.transform.position = pos;
            obj.GetComponent<ScrollObject>().SetEndLine(_destroyX);
            obj.SetActive(true);
        }

        private void Start()
        {
            float xpos = _spawnX;
            while(xpos > _destroyX)
            {
                Spawn(xpos);
                xpos -= _DistanceBetweenSpawns;
            }
        }

    }
}
