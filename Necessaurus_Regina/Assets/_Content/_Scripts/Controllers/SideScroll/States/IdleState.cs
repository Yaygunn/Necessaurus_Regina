using UnityEngine;

namespace SideScroller.Player.Controller
{
    public class IdleState : BaseState
    {
        public IdleState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
            base.Enter();
            if (_player.JumpCoyote > 0)
            {
                _player.ResetCoyote();
                _player.ChangeState(_player.airState);
                return;
            }
            if(_player.CrouchCoyote > 0)
            {
                _player.ResetCoyote();
                _player.ChangeState(_player.crouchState);
                return;
            }
            _player.scrollSpeedManager.IdleMod();
        }
        public override void Tick()
        {
            base.Tick();
        }
        public override void OnJump()
        {
            base.OnJump();
            _player.ChangeState(_player.airState);
            _player.scrollSpeedManager.Jump();
        }
        public override void OnCrouch()
        {
            base.OnCrouch();
            _player.scrollSpeedManager.Crouch();
            _player.ChangeState(_player.crouchState);
        }
        public override void Exit() 
        {
            base.Exit(); 

            _player.shapeChanger.EmptyLeg();
        }

        public override void OnDamage()
        {
            base.OnDamage();
            _player.ChangeState(_player.damageState);
        }
        public void RightStep()
        {
            _player.scrollSpeedManager.RightStep();

            _player.shapeChanger.RightStep();
        }

        public void LeftStep()
        {
            _player.scrollSpeedManager.LeftStep();

            _player.shapeChanger.LeftStep();
        }
    }
}
