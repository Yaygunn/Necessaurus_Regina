using UnityEngine;

namespace SideScroller.Components.ScrollObject
{
    public class ScrollObject : MonoBehaviour
    {
        private float _endX;
        private void OnEnable()
        {
            EventHub.Event_MoveSpeed += Scroll;
        }

        private void OnDisable()
        {
            EventHub.Event_MoveSpeed -= Scroll;
        }

        private void Scroll(float speed)
        {
            Vector3 pos = transform.position;
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;

            if(pos.x < _endX) 
            {
                ReachedEndLine();
            }
        }

        public void SetEndLine(float endX)
        {
            _endX = endX;
        }

        private void ReachedEndLine()
        {
            print("Reached");
            gameObject.SetActive(false);
        }
    }
}
