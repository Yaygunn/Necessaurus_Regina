using System;
using System.Collections;
using UnityEngine;

namespace BallGame.Components.Player.HitPoint
{
    public class BallHitPoint : MonoBehaviour
    {
        [SerializeField] private float _collisionEndTime = 0.2f;

        [SerializeField] private float _moveEndTime = 0.1f;

        private Action _endAction;

        private Collider2D _collider;
        
        private SpriteRenderer _spriteRenderer;

        private Color _normalColor= Color.white;

        private Color _pressedColor = Color.white;

        bool _onEndTime = true;

        private void Start()
        {
            _normalColor.a = 0;
            _collider = GetComponent<Collider2D>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _spriteRenderer.color = _normalColor;
            _pressedColor.a = 0.3f;
        }
        public void ActivateHit(Action endAction)
        {
            _endAction = endAction;
            _collider.enabled = true;
            _spriteRenderer.color = _pressedColor;

            StartCoroutine(EndOperation());
        }

        private IEnumerator EndOperation()
        {
            _onEndTime = false;
            yield return new WaitForSeconds(_collisionEndTime);

            _collider.enabled = false;
            _spriteRenderer.color = _normalColor;
            _onEndTime = true;

            yield return new WaitForSeconds(_moveEndTime);

            _endAction();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Ball"))
                return;

            _spriteRenderer.color = _normalColor;
            if(!_onEndTime)
            {
                StopAllCoroutines();
                StartCoroutine(End2());
            }
        }
        private IEnumerator End2()
        {
            _collider.enabled = false;
            _spriteRenderer.color = _normalColor;
            _onEndTime = true;

            yield return new WaitForSeconds(_moveEndTime);

            _endAction();
        }

    }
}
