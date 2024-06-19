using System.Collections;
using System.Collections.Generic;
using BallGame.UI;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 3f;
    
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    private void Start()
    {
        BallGameUI.Instance.OnCountdownStart.AddListener(ShowTutorial);
        BallGameUI.Instance.OnCountdownEnd.AddListener(HideTutorial);
    }
    
    public void ShowTutorial()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeOutCoroutine());
    }

    public void HideTutorial()
    {
        gameObject.SetActive(false);
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
    }

}
