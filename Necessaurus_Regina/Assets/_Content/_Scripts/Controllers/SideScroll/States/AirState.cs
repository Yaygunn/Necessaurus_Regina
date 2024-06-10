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
            _player.airComp.JumpTick();
        }

        public override void OnJump()
        {
            base.OnJump();
            _player.TriggerCoyoteJump();

        }
        public override void Exit() 
        {
            base.Exit(); 
        }

        private void Landed()
        {
            _player.ChangeState(_player.idleState);
        }
    }
}
