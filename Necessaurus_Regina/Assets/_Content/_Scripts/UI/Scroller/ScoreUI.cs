using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _scoreLabel;

    private void Start()
    {
        _scoreText.text = "0";
        HideScore();
        
        EventHub.Event_StartGame += InitializeScoreListening;
    }

    private void InitializeScoreListening()
    {
        _scoreText.gameObject.SetActive(true);
        _scoreLabel.gameObject.SetActive(true);
        EventHub.Event_PlayerScore += UpdateScore;
        EventHub.Event_EndGame += HideScore;
    }

    private void HideScore()
    {
        _scoreText.gameObject.SetActive(false);
        _scoreLabel.gameObject.SetActive(false);
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void OnDisable()
    {
        EventHub.Event_StartGame -= InitializeScoreListening;
        EventHub.Event_PlayerScore -= UpdateScore;
        EventHub.Event_EndGame -= HideScore;
    }
}
