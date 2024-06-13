namespace SideScroller.Player.Controller
{
    public class BaseState
    {
        protected PlayerController _player;

        public BaseState(PlayerController player)
        { 
            _player = player;
        }

        public virtual void Enter() { }
        public virtual void Tick() { }
        public virtual void OnJump() { }
        public virtual void OnCrouch() { }
        public virtual void OnEndCrouch() { }
        public virtual void Exit() { }
    }
}
