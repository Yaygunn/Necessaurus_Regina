using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private void Start()
    {
        _timerText.text = "00:00";
        HideTime();
        
        EventHub.Event_StartGame += InitializeTimerListening;
    }

    private void InitializeTimerListening()
    {
        _timerText.gameObject.SetActive(true);
        EventHub.Event_RemainingTime += UpdateTime;
        EventHub.Event_EndGame += HideTime;
    }

    private void HideTime()
    {
        _timerText.gameObject.SetActive(false);
    }

    private void UpdateTime(float time)
    {
        _timerText.text = $"{Mathf.FloorToInt(time / 60):00}:{Mathf.FloorToInt(time % 60):00}";
    }

    private void OnDisable()
    {
        EventHub.Event_StartGame -= InitializeTimerListening;
        EventHub.Event_RemainingTime -= UpdateTime;
        EventHub.Event_EndGame -= HideTime;
    }
}
