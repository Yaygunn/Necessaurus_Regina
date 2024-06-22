using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Component.Parallax
{
    public class ParallaxComp : MonoBehaviour
    {
        [SerializeField] private float _moveMultiplyConstant = 1;
        private float _length;
        private float _startX;

        void Start()
        {
            _length = GetComponent<SpriteRenderer>().bounds.size.x;
            _startX = transform.position.x;

            GameObject secondSprite = Instantiate(gameObject, transform.position + new Vector3(_length, 0, 0), Quaternion.identity, transform);
            Destroy(secondSprite.GetComponent<ParallaxComp>());

            EventHub.Event_ParallaxMove += Scroll;
        }

        private void OnDestroy()
        {
            EventHub.Event_ParallaxMove -= Scroll;
        }

        private void Scroll(float moveAmount)
        {
            float posX = transform.position.x;
            posX -= moveAmount * _moveMultiplyConstant;

            if (posX < _startX - _length)
                posX += _length;

            Vector3 pos = transform.position;
            pos.x = posX;
            transform.position = pos;
        }

    }
}
