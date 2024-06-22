using UnityEngine;

namespace SideScroller.Player.Controller
{
    public class AirState : BaseState
    {
        public AirState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
            base.Enter();
            _player.airComp.StartJump(Landed);
        }
        public override void Tick()
        {
            base.Tick();
        }

        public override void OnJump()
        {
            base.OnJump();
            _player.TriggerCoyoteJump();

        }
        public override void OnCrouch()
        {
            base.OnCrouch();
            _player.TriggerCoyoteCrouch();
        }
        public override void Exit() 
        {
            base.Exit(); 
        }
        public override void OnDamage()
        {
            base.OnDamage();
            _player.airComp.OnDamage();
            _player.ChangeState(_player.damageState);
        }

        private void Landed()
        {
            _player.ChangeState(_player.idleState);
        }
    }
}
