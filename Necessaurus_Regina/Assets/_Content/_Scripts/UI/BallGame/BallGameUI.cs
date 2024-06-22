using System.Collections;
using System.Collections.Generic;
using BallGame.Managers;
using Manager.LevelChanger;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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

        public UnityEvent OnCountdownStart;
        public UnityEvent OnCountdownEnd;
        
        private Coroutine _timerCoroutine;
        
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
                BallLevelManager.Instance.OnLevelEnd.RemoveListener(StopTimers);
            }
        }

        private void Start()
        {
            UpdateScoreText(BallScoreManager.Instance.GetScore());
            UpdateMove("", "");
            UpdateContestantName("Practice");
            
            if (BallScoreManager.Instance != null)
            {
                BallScoreManager.Instance.OnScoreChange.AddListener(UpdateScoreText);
            }

            if (BallLevelManager.Instance != null)
            {
                BallLevelManager.Instance.OnLevelEnd.AddListener(StopTimers);
            }
        }

        private void StopTimers()
        {
            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
            SetTimerText(0f);
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
            _timerCoroutine = StartCoroutine(TimerCoroutine(time));
        }

        private void SetTimerText(float time)
        {
            TimerText.text = $"Time: {Mathf.FloorToInt(time / 60):00}:{Mathf.FloorToInt(time % 60):00}";
        }

        private IEnumerator TimerCoroutine(float time)
        {
            while (time > 0)
            {
                time -= Time.deltaTime;
                SetTimerText(time);
                yield return null;
            }

            BallLevelManager.Instance.EndLevel();
        }
        
        public IEnumerator CountdownCoroutine()
        {
            OnCountdownStart?.Invoke();
            
            StartLevelText.gameObject.SetActive(false);
            CountdownText.gameObject.SetActive(true);

            for (int i = 3; i > 0; i--)
            {
                CountdownText.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }

            CountdownText.gameObject.SetActive(false);
            
            OnCountdownEnd?.Invoke();
        }

        public void RestartLevel()
        {
            LevelChanger.Instance.OpenBallGame();
        }
    }   
}
