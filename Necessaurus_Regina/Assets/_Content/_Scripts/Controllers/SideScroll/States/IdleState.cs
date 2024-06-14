using UnityEngine;

namespace SideScroller.Player.Controller
{
    public class IdleState : BaseState
    {
        enum E_Step { none, left, right }

        private E_Step _lastStep = E_Step.none;
        public IdleState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
            base.Enter();
            if (_player.JumpCoyote > 0)
            {
                _player.ResetCoyote();
                _player.ChangeState(_player.airState);
            }
            if(_player.CrouchCoyote > 0)
            {
                _player.ResetCoyote();
                _player.ChangeState(_player.crouchState);
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
            _lastStep = E_Step.none;
            _player.shapeChanger.EmptyLeg();
        }
        public void RightStep()
        {
            if (_lastStep == E_Step.right)
                return;

            _lastStep = E_Step.right;
            EventHub.PlayerStep();
            _player.shapeChanger.RightStep();
        }

        public void LeftStep()
        {
            if (_lastStep == E_Step.left)
                return;

            _lastStep = E_Step.left;
            EventHub.PlayerStep();
            _player.shapeChanger.LeftStep();
        }
    }
}
