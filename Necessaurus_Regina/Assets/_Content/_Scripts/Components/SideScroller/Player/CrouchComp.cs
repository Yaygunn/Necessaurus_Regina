using SideScroller.Components.ShapeChange;
using System;
using System.Collections;
using UnityEngine;

namespace SideScroller.Components.Crouch
{
    public class CrouchComp : MonoBehaviour
    {
        [SerializeField] private float _crouchEndTime;

        private ShapeChanger _shapeChanger;

        private Action _endAction;
        private void Start()
        {
            _shapeChanger = GetComponent<ShapeChange.ShapeChanger>();
        }

        public void StartCrouch(Action endCrouch)
        {
            _endAction = endCrouch;
            _shapeChanger.Crouch();
        }
        public void OnEndCrouchInput()
        {
            StartCoroutine(EndAction());
        }
        private IEnumerator EndAction()
        {
            yield return new WaitForSeconds( _crouchEndTime );
            EndCrouch();
        }
        private void EndCrouch()
        {
            _shapeChanger.Normal();
            _endAction();
        }


    }
}
