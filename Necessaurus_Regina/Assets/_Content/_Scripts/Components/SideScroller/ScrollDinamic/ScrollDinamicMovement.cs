using UnityEngine;

namespace Component.Scroll.DinamicMove
{
    public class ScrollDinamicMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private void Update()
        {
            transform.position = transform.position += new Vector3(-_moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
