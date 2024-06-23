using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SideScroller.Components.Jump;
using SideScroller.Components.Crouch;
using SideScroller.Components.ShapeChange;
using Manager.ScrollSpeedManager;

namespace SideScroller.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        #region States
        public IdleState idleState {  get; private set; }
        public AirState airState { get; private set; }
        public CrouchState crouchState { get; private set; }
        public DamageState damageState { get; private set; }
        #endregion

        #region Components
        public AirComp airComp { get; private set; }
        public CrouchComp crouchComp { get; private set; }
        public ShapeChanger shapeChanger { get; private set; }

        public ScrollSpeedManager scrollSpeedManager { get; private set; }
        #endregion

        public float JumpCoyote {  get; private set; }
        private float _maxCoyote { get; } = 0.2f;

        public bool CrouchPressed { get; private set; }
        public BaseState CurrentState { get; private set; }
        private void Start()
        {
            idleState = new IdleState(this);
            airState = new AirState(this);
            crouchState = new CrouchState(this);
            damageState = new DamageState(this);

            airComp = GetComponent<AirComp>();
            crouchComp = GetComponent<CrouchComp>();
            shapeChanger = GetComponent<ShapeChanger>();
            scrollSpeedManager = GetComponent<ScrollSpeedManager>();

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
            CrouchPressed = true;
            TriggerCoyoteCrouch();
        }
        public void OnEndCrouch()
        {
            CurrentState.OnEndCrouch();
            CrouchPressed = false;
        }

        public void TriggerCoyoteJump()
        {
            JumpCoyote = _maxCoyote;
        }

        public void TriggerCoyoteCrouch()
        {
            JumpCoyote = 0;
        }
        public void ResetCoyote()
        {
            JumpCoyote = 0;
        }
        private void CoyoteTimer()
        {
            JumpCoyote -= Time.deltaTime;
        }
    }
}
