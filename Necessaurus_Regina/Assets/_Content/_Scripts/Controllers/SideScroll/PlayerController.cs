using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideScroller.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        #region States
        public IdleState idleState {  get; private set; }
        public JumpState jumpState { get; private set; }
        public CrouchState crouchState { get; private set; }
        #endregion

        #region Components
        #endregion

        public BaseState CurrentState { get; private set; }
        private void Start()
        {
            idleState = new IdleState(this);
            jumpState = new JumpState(this);
            crouchState = new CrouchState(this);

            CurrentState = idleState;
            CurrentState.Enter();
        }

        public void ChangeState(BaseState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void OnJump()
        {
            CurrentState.OnJump();
        }

        public void OnCrouch()
        {
            CurrentState.OnCrouch();
        }
    }
}
