using UnityEngine;
using UnityEngine.InputSystem;

namespace Input.BallGame
{
    public class Input_BallGame : MonoBehaviour, Keys.IBallGameActions
    {
        private Keys _input;

        private void Awake()
        {
            _input = new Keys();
        }
        private void OnEnable()
        {
            _input.BallGame.SetCallbacks(this);
            _input.BallGame.Enable();
        }
        private void OnDisable()
        {
            _input.BallGame.RemoveCallbacks(this);
            _input.BallGame.Disable();
        }
        public void OnHeadHit(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                print("head");
        }

        public void OnLeftFoot(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                print("left");
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            float f = context.ReadValue<float>();
            if (f != 0)
            {
                print(f);
            }
        }

        public void OnRightFoot(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                print("right");
        }
    }

}
