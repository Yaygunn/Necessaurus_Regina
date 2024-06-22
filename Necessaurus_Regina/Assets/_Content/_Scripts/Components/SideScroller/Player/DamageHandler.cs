using SideScroller.Components.ShapeChange;
using SideScroller.Player.Controller;
using System.Collections;
using UnityEngine;

namespace SideScroller.Components.Damage
{
    public class DamageHandler : MonoBehaviour
    {
        private bool _isDamaged;

        private PlayerController _playerController;

        private ShapeChanger _shapeChanger;

        [SerializeField] private float _damageTime;

        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _shapeChanger = GetComponent<ShapeChanger>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacle"))
            {
                if (_isDamaged)
                    return;

                _isDamaged = true;
                _playerController.CurrentState.OnDamage();
                _shapeChanger.GetDamage();
                StartCoroutine(EndDamageState());
            }
        }

        private IEnumerator EndDamageState()
        {
            yield return new WaitForSeconds(_damageTime);

            _isDamaged = false;
            _shapeChanger.Normal();
            _shapeChanger.RecoverDamage();
            _playerController.ChangeState(_playerController.idleState);
        }
    }
}
