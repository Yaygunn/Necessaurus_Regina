using UnityEngine;

namespace SideScroller.Player.Controller
{
    public class CrouchState : BaseState
    {
        public CrouchState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Crouchhh");
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
