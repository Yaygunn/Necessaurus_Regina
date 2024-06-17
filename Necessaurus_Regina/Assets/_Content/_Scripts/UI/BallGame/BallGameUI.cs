using System.Collections;
using System.Collections.Generic;
using BallGame.Managers;
using Manager.LevelChanger;
using TMPro;
using UnityEngine;

namespace BallGame.UI
{
    public class BallGameUI : MonoBehaviour
    {
        [Header("UI Elements")]
        public TextMeshProUGUI ScoreText;
        public TextMeshProUGUI MoveNameText;
        public TextMeshProUGUI MovePointsText;
        public TextMeshProUGUI TimerText;
        public TextMeshProUGUI ContestantNameText;
        public TextMeshProUGUI StartLevelText;
        public TextMeshProUGUI CountdownText;
        
        [Header("Game Over Panel")]
        public GameObject GameOverPanel;
        public TextMeshProUGUI GaveOverScore;
        
        public static BallGameUI Instance { get; private set; }

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
        }
        
        private void OnDisable()
        {
            if (BallScoreManager.Instance != null)
            {
                BallScoreManager.Instance.OnScoreChange.RemoveListener(UpdateScoreText);
            }
            
            if (BallLevelManager.Instance != null)
            {
                BallLevelManager.Instance.OnLevelEnd.RemoveListener(ShowGameOverPanel);
            }
        }

        public void ShowGameOverPanel()
        {
            GaveOverScore.text = BallScoreManager.Instance.GetScore().ToString();
            GameOverPanel.SetActive(true);
        }

        public void HideGameOverPanel()
        {
            GameOverPanel.SetActive(false);
        }

        private void Start()
        {
            HideGameOverPanel();
            UpdateScoreText(BallScoreManager.Instance.GetScore());
            UpdateMove("", "");
            UpdateContestantName("Practice");
            
            
            if (BallLevelManager.Instance != null)
            {
                BallLevelManager.Instance.OnLevelEnd.AddListener(ShowGameOverPanel);
            }
            
            if (BallScoreManager.Instance != null)
            {
                BallScoreManager.Instance.OnScoreChange.AddListener(UpdateScoreText);
            }
        }

        private void UpdateScoreText(int score, BallMove move = null)
        {
            if (ScoreText == null)
                return;
            
            ScoreText.text = score.ToString();

            if (move != null)
            {
                if (move.ShowNameOnScore)
                {
                    UpdateMove(move.MoveName, move.MovePoints.ToString());
                    StartCoroutine(ClearMoveText());
                }   
            }
        }

        private IEnumerator ClearMoveText()
        {
            yield return new WaitForSeconds(2);
            UpdateMove("", "");
        }

        private void UpdateMove(string moveName, string points)
        {
            MoveNameText.text = moveName;
            MovePointsText.text = points;
        }

        private void UpdateContestantName(string name)
        {
            ContestantNameText.text = name;
        }
        
        public void SetTimer(float time)
        {
            StartCoroutine(TimerCoroutine(time));
        }

        private IEnumerator TimerCoroutine(float time)
        {
            while (time > 0)
            {
                time -= Time.deltaTime;
                TimerText.text = $"Time: {Mathf.FloorToInt(time / 60):00}:{Mathf.FloorToInt(time % 60):00}";
                yield return null;
            }

            BallLevelManager.Instance.EndLevel();
        }
        
        public IEnumerator CountdownCoroutine()
        {
            StartLevelText.gameObject.SetActive(false);
            CountdownText.gameObject.SetActive(true);

            for (int i = 3; i > 0; i--)
            {
                CountdownText.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }

            CountdownText.gameObject.SetActive(false);
        }

        public void RestartLevel()
        {
            LevelChanger.Instance.OpenBallGame();
        }
    }   
}
