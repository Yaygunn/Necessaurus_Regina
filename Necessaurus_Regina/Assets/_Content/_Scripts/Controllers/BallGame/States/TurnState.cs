namespace BallGame.Player.Controller
{
    public class TurnState : BaseState
    {
        public TurnState(PlayerController player, float turnDuration) : base(player) 
        { 
            TurnTimer = turnDuration;
        }
        
        public float TurnTimer { get; private set; }
        private float _turnTimer;

        public override void Enter() 
        { 
            base.Enter();
            
            _turnTimer = TurnTimer;
        }
        public override void Tick(float dt)
        { 
            base.Tick(dt);
            
            _turnTimer -= dt;
            
            if (_turnTimer <= 0)
            {
                _player.ChangeState(_player.moveState);
            }
        }
        
        public override void Exit() 
        { 
            base.Exit();
        }
    }
}
