namespace BallGame.Player.Controller
{
    public class BaseState
    {
        protected PlayerController _player;

        public BaseState(PlayerController player)
        {
            _player = player;
        }

        public virtual void Enter() { }
        public virtual void Tick(float dt) { }
        public virtual void OnPrimaryAction() { }
        public virtual void Exit() { }
    }
}
