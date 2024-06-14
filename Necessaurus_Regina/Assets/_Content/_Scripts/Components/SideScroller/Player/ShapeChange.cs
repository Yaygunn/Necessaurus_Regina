using UnityEngine;

namespace SideScroller.Components.ShapeChange
{
    public class ShapeChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _crouch;

        [SerializeField] private GameObject _normal;

        [Header("Legs")]
        [SerializeField] private GameObject _leftlegActive;
        [SerializeField] private GameObject _rightlegACtive;

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

        public void LeftStep()
        {
            _leftlegActive.SetActive(true);
            _rightlegACtive.SetActive(false);
        }
        public void RightStep()
        {
            _leftlegActive.SetActive(false);
            _rightlegACtive.SetActive(true);
        }
        public void EmptyLeg()
        {
            _leftlegActive.SetActive(false);
            _rightlegACtive.SetActive(false);
        }
    }
}
