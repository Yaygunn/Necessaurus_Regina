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

    private void Start()
    {
        ShowScreen("Menu");
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
}
