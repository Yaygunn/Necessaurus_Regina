using UnityEngine;

namespace SideScroller.Components.ShapeChange
{
    public class ShapeChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _crouch;

        [SerializeField] private GameObject _normal;


        public void Crouch()
        {
            _crouch.SetActive(true);
            _normal.SetActive(false);
        }

        public void Normal()
        {
            _crouch.SetActive(false);
            _normal.SetActive(true);
        }
    }
}
