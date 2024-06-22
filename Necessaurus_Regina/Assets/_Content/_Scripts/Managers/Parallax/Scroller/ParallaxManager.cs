using UnityEngine;

namespace Manager.Parallax.Scroller
{
    public class ParallaxManager : MonoBehaviour
    {
        [SerializeField] private float _parallaxSpeedMultiplyConstant = 1;
        private void OnEnable()
        {
            EventHub.Event_MoveSpeed += Scroll;
        }

        private void OnDisable()
        {
            EventHub.Event_MoveSpeed -= Scroll;
        }

        private void Scroll(float moveAmount)
        {
            EventHub.ParallaxMove(moveAmount * _parallaxSpeedMultiplyConstant * Time.deltaTime);
        }
    }
}
