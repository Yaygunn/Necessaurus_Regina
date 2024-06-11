using UnityEngine;

namespace BallGame.Player.Controller
{
    public enum E_HitVersions { head, left, right}
    public class HitBallState : BaseState
    {
        public HitBallState(PlayerController player) : base(player) { }

        public override void Enter()
        {
            base.Enter();
            switch(_player.CurrentHitMove)
            {
                case E_HitVersions.head:
                    Debug.Log("Hit Head");
                    break;
                case E_HitVersions.left:
                    Debug.Log("Hit Left");
                    break;
                case E_HitVersions.right:
                    Debug.Log("Hit Right");
                    break;
            }
            _player.ResetCoyoteTime();
            //_player.ChangeState(_player.moveState);
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
