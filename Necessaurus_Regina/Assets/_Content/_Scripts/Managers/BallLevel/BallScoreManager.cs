using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BallGame.Managers
{
    public class BallScoreManager : MonoBehaviour
    {
        public static BallScoreManager Instance;
        public UnityEvent<int> OnScoreChange;

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
            
            OnScoreChange = new UnityEvent<int>();
        }

        public void AddScore(int points)
        {
            score += points;
            OnScoreChange.Invoke(score);    
        }

        public int GetScore()
        {
            return score;
        }
    }   
}
