using BallGame.Player.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BallGame.Managers
{
    public class BallScoreManager : MonoBehaviour
    {
        public static BallScoreManager Instance;
        public BallMovesDatabase BallMovesDatabase;
        public UnityEvent<int, BallMove> OnScoreChange;

        private int score;
        private List<BallActionType> actionSequence = new List<BallActionType>();
        private const int maxSequenceLength = 10;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
            OnScoreChange = new UnityEvent<int, BallMove>();
        }

        public void AddAction(E_HitVersions hitVersion)
        {
            BallActionType action = ConvertHitTypeToBallActionType(hitVersion);
            actionSequence.Add(action);
            
            if (actionSequence.Count > maxSequenceLength)
            {
                actionSequence.RemoveAt(0);
            }

            CheckSequenceForMove();
        }
        private BallActionType ConvertHitTypeToBallActionType(E_HitVersions hitType)
        {
            switch (hitType)
            {
                case E_HitVersions.left: return BallActionType.LeftFoot;
                case E_HitVersions.right: return BallActionType.RightFoot;
                case E_HitVersions.head: return BallActionType.Head;
                case E_HitVersions.chest: return BallActionType.Chest;
                case E_HitVersions.turn: return BallActionType.Turn;
                default: return BallActionType.None;
            }
        }

        private void CheckSequenceForMove()
        {
            foreach (BallMove move in BallMovesDatabase.BallMoves)
            {
                if (move.ShowNameOnScore == false) continue;
                
                if (DoesSequenceMatch(move.ActionSequence))
                {
                    // See if we can't rather just pass in the move object
                    AddScore(move.MoveName);
                    actionSequence.Clear();
                    
                    break;
                }
            }
        }

        private bool DoesSequenceMatch(List<BallActionType> sequence)
        {
            if (actionSequence.Count < sequence.Count)
            {
                return false;
            }

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] == BallActionType.AnyHit && IsAnyHit(actionSequence[actionSequence.Count - sequence.Count + i]))
                {
                    continue;
                }
                
                if (actionSequence[actionSequence.Count - sequence.Count + i] != sequence[i])
                {
                    return false;
                }
            }
            
            return true;
        }

        private bool IsAnyHit(BallActionType action)
        {
            return action == BallActionType.LeftFoot || action == BallActionType.RightFoot || action == BallActionType.Head || action == BallActionType.Chest;
        }

        public void AddScore(string moveName)
        {
            // Very inefficient
            BallMove move = BallMovesDatabase.BallMoves.Find(x => x.MoveName == moveName);
            if (move != null)
            {
                score += move.MovePoints;
                OnScoreChange.Invoke(score, move);
            }
            else
            {
                Debug.LogError($"Move {moveName} not found in the database.");
            }
        }

        public int GetScore()
        {
            return score;
        }

        public void ClearActions()
        {
            actionSequence.Clear();
        }
    }   
}
