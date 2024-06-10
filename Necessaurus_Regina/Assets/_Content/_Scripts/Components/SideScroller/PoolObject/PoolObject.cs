using System;
using UnityEngine;

namespace Component.PoolObject
{
    public class PoolObject : MonoBehaviour
    {
        private GameObject _signObject;
        private Action<GameObject, GameObject> _returnAction;

        public void SetReturnDependencies(GameObject signObject, Action<GameObject, GameObject> returnAction)
        {
            _signObject = signObject;
            _returnAction = returnAction;
        }

        private void OnDisable()
        {

            _returnAction?.Invoke(_signObject, gameObject);
        }
    }
}
