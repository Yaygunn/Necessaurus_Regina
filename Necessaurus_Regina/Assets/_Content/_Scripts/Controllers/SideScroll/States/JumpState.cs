using UnityEngine;

namespace SideScroller.Player.Controller
{
    public class JumpState : BaseState
    {
        public JumpState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Jumpppp");
        }
        public override void Tick()
        {
            base.Tick();
        }
        public override void Exit() 
        {
            base.Exit(); 
        }
    }
}
