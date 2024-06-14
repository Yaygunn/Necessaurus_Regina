using SideScroller.Components.ScrollObject;
using UnityEngine;

namespace Manager.SideScroll.Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private ObstaclesData _obstacles;

        [Header("DistanceBetweenSpawns")]
        [SerializeField] private float _minDistanceBetweenSpawns;
        [SerializeField] private float _maxDistanceBetweenSpawns;

        [Header("Positions")]
        [SerializeField] private float _spawnX;
        [SerializeField] private float _destroyX;

        private float _distanceSinceLastSpawn;

        private float _distanceForNextSpawn = 20;

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
            if(_distanceSinceLastSpawn >= _distanceForNextSpawn)
            {
                _distanceSinceLastSpawn -= _distanceForNextSpawn;
                Spawn();
                CalculateNextSpawnDistance();
            }
        }
        private void Spawn()
        {
            GameObject obj = _obstacles.GetRandomObject();
            Vector3 pos = new Vector3(_spawnX, 0, 0);
            obj.transform.position = pos;
            obj.GetComponent<ScrollObject>().SetEndLine(_destroyX);
            obj.SetActive(true);
        }
        private void CalculateNextSpawnDistance()
        {
            _distanceForNextSpawn = Random.Range(_minDistanceBetweenSpawns, _maxDistanceBetweenSpawns);
        }
    }
}