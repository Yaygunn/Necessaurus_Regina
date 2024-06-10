using UnityEngine;
using SideScroller.Player.Controller;
using UnityEngine.InputSystem;

namespace Input.SideScroller
{
    public class Input_SideScroller : MonoBehaviour, Keys.ISideScrollerActions
    {
        [SerializeField] private PlayerController _controller;

        private Keys _input;

        private void Awake()
        {
            _input = new Keys();
        }
        private void OnEnable()
        {
            _input.SideScroller.SetCallbacks(this);
            _input.SideScroller.Enable();
        }
        private void OnDisable()
        {
            _input.SideScroller.RemoveCallbacks(this);
            _input.SideScroller.Disable();
        }
        public void OnCrouch(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
                _controller.OnCrouch();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                _controller.OnJump();
        }
    }
}
