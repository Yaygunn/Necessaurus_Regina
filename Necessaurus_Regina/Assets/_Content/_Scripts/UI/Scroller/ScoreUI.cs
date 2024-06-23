using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText.text = "0";
        _scoreText.gameObject.SetActive(false);
        
        EventHub.Event_StartGame += InitializeScoreListening;
    }

    private void InitializeScoreListening()
    {
        _scoreText.gameObject.SetActive(true);
        EventHub.Event_PlayerScore += UpdateScore;
        EventHub.Event_EndGame += HideScore;
    }

    private void HideScore()
    {
        _scoreText.gameObject.SetActive(false);
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
