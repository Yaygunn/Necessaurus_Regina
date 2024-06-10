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
            }
        }
        public override void Tick()
        {
            base.Tick();
        }
        public override void OnJump()
        {
            base.OnJump();
            _player.ChangeState(_player.airState);
        }
        public override void OnCrouch()
        {
            base.OnCrouch();
            _player.ChangeState(_player.crouchState);
        }
        public override void Exit() 
        {
            base.Exit(); 
        }
    }
}
