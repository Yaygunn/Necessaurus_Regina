using UnityEngine;

namespace SideScroller.Player.Controller
{
    public class CrouchState : BaseState
    {
        public CrouchState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
            base.Enter();

            _player.crouchComp.StartCrouch(EndOfCrouch);
        }
        public override void Tick()
        {
            base.Tick();

            _player.crouchComp.Tick();
        }
        public override void Exit() 
        {
            base.Exit(); 
        }

        private void EndOfCrouch()
        {
            _player.ChangeState(_player.idleState);
        }
    }
}
