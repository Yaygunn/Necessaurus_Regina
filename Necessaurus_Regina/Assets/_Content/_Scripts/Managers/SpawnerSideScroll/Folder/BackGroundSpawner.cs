using Scriptable.BackGroundHolder;
using SideScroller.Components.ScrollObject;
using UnityEngine;

namespace Manager.SideScroll.Spawner.BackGround
{
    public class BackGroundSpawner : MonoBehaviour
    {
        [Header("DistanceBetweenSpawns")]
        [SerializeField] private float _minDistanceBetweenSpawns;
        [SerializeField] private float _maxDistanceBetweenSpawns;

        private float _distanceFormNextSpawn;

        private float _distanceSinceLastSpawn;

        [SerializeField] private BackGroundHolder _backGroundHolder;

        [Header("Positions")]
        [SerializeField] private float _destroyX;


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
            if (_distanceSinceLastSpawn >= _distanceFormNextSpawn)
            {
                _distanceSinceLastSpawn -= _distanceFormNextSpawn;
                Spawn();
                SelectNewSpawnDistance();
            }
        }
        private void Spawn()
        {
            GameObject obj = _backGroundHolder.GetRandomObject();
            obj.GetComponent<ScrollObject>().SetEndLine(_destroyX);
            obj.SetActive(true);
        }

        private void SelectNewSpawnDistance()
        {
            _distanceFormNextSpawn = UnityEngine.Random.Range(_minDistanceBetweenSpawns, _maxDistanceBetweenSpawns);
        }
     
    }
}
