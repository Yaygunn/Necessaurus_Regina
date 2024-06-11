using BallGame.Components.Player.Move;
using UnityEngine;


namespace BallGame.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        public BaseState CurrentState { get; private set; }
        public MoveState moveState { get; private set; }
        public HitBallState hitBallState { get; private set; }

        public Move MoveComp { get; private set; }

        public float MoveInput {  get; private set; }
        
        public E_HitVersions CurrentHitMove {  get; private set; }
        public float HitTime {  get; private set; }
        private float _hitCoyoteTime { get; } = 0.2f;
        void Start()
        {
            moveState = new MoveState(this);
            hitBallState = new HitBallState(this);

            MoveComp = GetComponent<Move>();

            CurrentState = moveState;
            CurrentState.Enter();
        }

        
        void Update()
        {
            CurrentState.Tick();
            ReduceCoyoteTime();
        }

        public void ChangeState(BaseState newState)
        {
            if (newState == CurrentState)
                return;

            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void OnMoveInput(float input)
        {
            MoveInput = input;
        }

        public void OnHead()
        {
            CurrentHitMove = E_HitVersions.head;
            HitTime = _hitCoyoteTime;
        }

        public void OnLeftFoot()
        {
            CurrentHitMove = E_HitVersions.left;
            HitTime = _hitCoyoteTime;
        }

        public void OnRightFoot()
        {
            CurrentHitMove = E_HitVersions.right;
            HitTime = _hitCoyoteTime;
        }

        private void ReduceCoyoteTime()
        {
            HitTime -= Time.deltaTime;
        }

        public void ResetCoyoteTime()
        {
            HitTime = 0;
        }

    }
}
