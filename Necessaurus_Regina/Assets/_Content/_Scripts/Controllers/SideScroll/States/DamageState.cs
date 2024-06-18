using UnityEngine;

namespace SideScroller.Player.Controller
{
    public class DamageState : BaseState
    {
        public DamageState(PlayerController controller) : base(controller) { }

        public override void Enter()
        {
            base.Enter();
            _player.scrollSpeedManager.DamageMod();
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
