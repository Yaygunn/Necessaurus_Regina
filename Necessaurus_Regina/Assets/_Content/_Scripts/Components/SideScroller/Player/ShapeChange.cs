using UnityEngine;

namespace SideScroller.Components.ShapeChange
{
    public class ShapeChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _crouch;

        [SerializeField] private GameObject _normal;

        [SerializeField] private GameObject _damaged;

        [Header("Legs")]
        [SerializeField] private GameObject _leftlegActive;
        [SerializeField] private GameObject _rightlegACtive;

        [Header("AnimationController")]
        [SerializeField] Animator _animator;

        // ap = anim parameter
        private string _apBool_Jump { get; } = "Jump";
        private string _apBool_Fall { get; } = "Fall";

        [Header("Colliders")]
        [SerializeField] private Collider2D _normalCollider;

        public void Crouch()
        {
            _crouch.SetActive(true);
            _normal.SetActive(false);
            _normalCollider.enabled = false;
        }

        public void Normal()
        {
            _crouch.SetActive(false);
            _normal.SetActive(true);
            _damaged.SetActive(false);
            _normalCollider.enabled = true;
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

        public void GetDamage()
        {
            _crouch.SetActive(false);
            _normal.SetActive(false);
            EmptyLeg();
            _damaged.SetActive(true);

            _animator.SetBool(_apBool_Fall, true);
            _animator.SetBool(_apBool_Jump, false);
        }
        public void Jump()
        {
            _animator.SetBool(_apBool_Jump, true);
        }
        public void Land()
        {
            _animator.SetBool(_apBool_Jump, false);
        }
        public void RecoverDamage()
        {
            _animator.SetBool(_apBool_Fall, false);
        }
    }
}
