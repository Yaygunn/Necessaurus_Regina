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

        public void AddScore(string moveName)
        {
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
    }   
}
