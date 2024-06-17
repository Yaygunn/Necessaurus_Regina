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

        private void Start()
        {
            _collider = GetComponent<Collider2D>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        public void ActivateHit(Action endAction)
        {
            _endAction = endAction;
            _collider.enabled = true;
            _spriteRenderer.color = Color.yellow;

            StartCoroutine(EndOperation());
        }

        private IEnumerator EndOperation()
        {
            yield return new WaitForSeconds(_collisionEndTime);

            _collider.enabled = false;
            _spriteRenderer.color = Color.white;

            yield return new WaitForSeconds(_moveEndTime);

            _endAction();
        }

    }
}
