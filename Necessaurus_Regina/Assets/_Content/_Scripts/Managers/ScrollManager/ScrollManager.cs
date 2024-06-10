using UnityEngine;

namespace Manager.SideScroll
{
    public class ScrollManager : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private void Update()
        {
            EventHub.MoveSpeed(_moveSpeed);
        }
    }
}
