using SideScroller.Components.ShapeChange;
using System;
using UnityEngine;

namespace SideScroller.Components.Crouch
{
    public class CrouchComp : MonoBehaviour
    {
        [SerializeField] private float _crouchEndTime;

        private ShapeChanger _shapeChanger;

        private float _crouchTime;

        private Action _endAction;
        private void Start()
        {
            _shapeChanger = GetComponent<ShapeChange.ShapeChanger>();
        }

        public void StartCrouch(Action endCrouch)
        {
            _endAction = endCrouch;
            _crouchTime = 0;
            _shapeChanger.Crouch();
        }

        public void Tick()
        {
            _crouchTime += Time.deltaTime;
            if(_crouchTime > _crouchEndTime)
                EndCrouch();
        }

        private void EndCrouch()
        {
            _shapeChanger.Normal();
            _endAction();
        }

    }
}
