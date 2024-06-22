using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject playScreen;
    public GameObject settingsScreen;
    public GameObject creditsScreen;
    public List<CreditsPerson> creditsPeople = new List<CreditsPerson>();
    public CreditPersonEntry creditPersonEntryPrefab;
    public RectTransform creditsContainer;
    public float scrollSpeed = 20f;
    
    private Coroutine scrollCoroutine;

    private void Start()
    {
        ShowScreen("Menu");
        LoadCredits();
    }
    
    public void ShowScreen(string screen)
    {
        menuScreen.SetActive(screen == "Menu");
        playScreen.SetActive(screen == "Play");
        settingsScreen.SetActive(screen == "Settings");
        creditsScreen.SetActive(screen == "Credits");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
    public void LoadScene(int sceneId)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
    }

    private void LoadCredits()
    {
        foreach (CreditsPerson person in creditsPeople)
        {
            CreditPersonEntry creditPersonEntry = Instantiate(creditPersonEntryPrefab, creditsContainer);
            creditPersonEntry.Initialize(person);
        }
    }

    public void ShowCredits()
    {
        scrollCoroutine = StartCoroutine(ScrollCredits());
    }

    public void CancelCredits()
    {
        if (scrollCoroutine != null)
        {
            StopCoroutine(scrollCoroutine);
            scrollCoroutine = null;
        }
    }

    private IEnumerator ScrollCredits()
    {
        // Apparanlty needed to wait for the next frame for the RectTransform to be updated
        yield return new WaitForEndOfFrame();
        
        float panelHeight = creditsContainer.GetComponent<RectTransform>().rect.height;
        creditsContainer.anchoredPosition = new Vector2(creditsContainer.anchoredPosition.x, -panelHeight * 0.2f);
        
        while (true)
        {
            creditsContainer.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
            yield return null;

            if (creditsContainer.anchoredPosition.y >= creditsContainer.rect.height)
            {
                creditsContainer.anchoredPosition = new Vector2(creditsContainer.anchoredPosition.x, -creditsContainer.rect.height);
            }
        }
    }

}
