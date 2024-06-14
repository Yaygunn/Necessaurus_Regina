using System.Collections;
using System.Collections.Generic;
using BallGame.Managers;
using TMPro;
using UnityEngine;

namespace BallGame.UI
{
    public class BallGameUI : MonoBehaviour
    {
        [Header("UI Elements")]
        public TextMeshProUGUI ScoreText;
        
        private void OnDisable()
        {
            if (BallScoreManager.Instance != null)
            {
                BallScoreManager.Instance.OnScoreChange.RemoveListener(UpdateScoreText);
            }
        }

        private void Start()
        {
            if (BallScoreManager.Instance != null)
            {
                BallScoreManager.Instance.OnScoreChange.AddListener(UpdateScoreText);
            }
            
            UpdateScoreText(BallScoreManager.Instance.GetScore());
        }

        private void UpdateScoreText(int score)
        {
            if (ScoreText == null)
                return;
            
            ScoreText.text = score.ToString();
        }
    }   
}
