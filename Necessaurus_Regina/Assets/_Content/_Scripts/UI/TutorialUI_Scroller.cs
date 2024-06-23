using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI_Scroller : MonoBehaviour
{
    private Coroutine _tutorialFadeCoroutine;
    private float fadeDuration = 1.5f;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void OnEnable()
    {
        EventHub.Event_StartGame += OnStart;
    }

    private void OnDisable()
    {
        EventHub.Event_StartGame -= OnStart;
    }

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnStart()
    {
        _tutorialFadeCoroutine = StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float startAlpha = canvasGroup.alpha;
        float rate = 1.0f / fadeDuration;

        for (float t = 0; t < 1.0f; t += Time.deltaTime * rate)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, t);
            yield return null;
        }

        canvasGroup.alpha = 0;
        gameObject.SetActive(false);
        StopCoroutine(_tutorialFadeCoroutine);
        _tutorialFadeCoroutine = null;
    }
}
