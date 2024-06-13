using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SideScroller.Components.Jump;
using SideScroller.Components.Crouch;

namespace SideScroller.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        #region States
        public IdleState idleState {  get; private set; }
        public AirState airState { get; private set; }
        public CrouchState crouchState { get; private set; }
        #endregion

        #region Components
        public AirComp airComp { get; private set; }
        public CrouchComp crouchComp { get; private set; }
        #endregion

        public float JumpCoyote {  get; private set; }
        public float CrouchCoyote { get; private set; }
        private float _maxCoyote { get; } = 0.2f;
        public BaseState CurrentState { get; private set; }
        private void Start()
        {
            idleState = new IdleState(this);
            airState = new AirState(this);
            crouchState = new CrouchState(this);

            airComp = GetComponent<AirComp>();
            crouchComp = GetComponent<CrouchComp>();

            CurrentState = idleState;
            CurrentState.Enter();
        }

        private void Update()
        {
            CurrentState.Tick();
            CoyoteTimer();
        }
        public void ChangeState(BaseState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void OnRightStep()
        {
            if(CurrentState == idleState)
                idleState.RightStep();
        }
        public void OnLeftStep()
        {
            if (CurrentState == idleState)
                idleState.LeftStep();
        }
        public void OnJump()
        {
            CurrentState.OnJump();
        }
        public void OnCrouch()
        {
            CurrentState.OnCrouch();
        }
        public void OnEndCrouch()
        {
            CurrentState.OnEndCrouch();
        }

        public void TriggerCoyoteJump()
        {
            JumpCoyote = _maxCoyote;
            CrouchCoyote = 0;
        }

        public void TriggerCoyoteCrouch()
        {
            CrouchCoyote = _maxCoyote;
            JumpCoyote = 0;
        }
        public void ResetCoyote()
        {
            CrouchCoyote = 0;
            JumpCoyote = 0;
        }
        private void CoyoteTimer()
        {
            CrouchCoyote -=Time.deltaTime;
            JumpCoyote -= Time.deltaTime;
        }
    }
}
