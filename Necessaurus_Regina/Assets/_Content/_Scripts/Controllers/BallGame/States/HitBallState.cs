using UnityEngine;

namespace BallGame.Player.Controller
{
    public enum E_HitVersions { head, left, right, chest, turn }
    public class HitBallState : BaseState
    {
        public HitBallState(PlayerController player) : base(player) { }

        public override void Enter()
        {
            base.Enter();
            
            switch(_player.CurrentHitMove)
            {
                case E_HitVersions.head:
                    _player.HeadHitPoint.ActivateHit(HitEndAction);
                    break;
                case E_HitVersions.chest:
                    _player.ChestHitPoint.ActivateHit(HitEndAction);
                    break;
                case E_HitVersions.left:
                    _player.LeftLegHitPoint.ActivateHit(HitEndAction);
                    break;
                case E_HitVersions.right:
                    _player.RightLegHitPoint.ActivateHit(HitEndAction);
                    break;
            }
            
             _player.ResetCoyoteTime();
        }
        public override void Tick(float dt)
        {
            base.Tick(dt);
        }
        public override void Exit()
        {
            base.Exit();
        }

        private void HitEndAction()
        {
            _player.ChangeState(_player.moveState);
        }
    }
}
