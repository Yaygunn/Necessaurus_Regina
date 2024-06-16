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
    public Transform creditsContainer;

    private void Start()
    {
        ShowScreen("Menu");
        
        // Initialize credits once off
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
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
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
}
