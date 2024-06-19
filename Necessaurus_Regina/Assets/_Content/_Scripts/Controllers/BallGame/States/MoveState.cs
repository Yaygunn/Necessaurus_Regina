namespace BallGame.Player.Controller
{
    public class MoveState : BaseState
    {
        public MoveState(PlayerController player):base(player) { }

        public override void Enter() 
        { 
            base.Enter();
        }
        public override void Tick(float dt)
        { 
            base.Tick(dt);

            _player.MoveComp.GetMoveInput(_player.MoveInput);
            if (_player.HitTime > 0)
            {
                _player.MoveComp.GetMoveInput(0);
                _player.ChangeState(_player.hitBallState);
            }
        }

        public override void OnPrimaryAction()
        {
            base.OnPrimaryAction();
            
            // Rotate the player 360deg over X time and lock movement
        }
        
            
        public override void Exit() 
        { 
            base.Exit();
            
            _player.MoveComp.GetMoveInput(0);
        }
    }
}
