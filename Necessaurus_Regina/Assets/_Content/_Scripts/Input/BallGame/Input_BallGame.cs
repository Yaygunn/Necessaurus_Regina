using BallGame.Player.Controller;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input.BallGame
{
    public class Input_BallGame : MonoBehaviour, Keys.IBallGameActions
    {
        [SerializeField] private PlayerController _playerController;
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
                _playerController.OnHead();
        }

        public void OnLeftFoot(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                _playerController.OnLeftFoot();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _playerController.OnMoveInput(context.ReadValue<float>());
            
        }

        public void OnRightFoot(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                _playerController.OnRightFoot();
        }
    }

}
