using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager.LevelChanger
{
    public class LevelChanger : MonoBehaviour
    {
        public static LevelChanger Instance { get; private set; }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void OpenMainMenu()
        {
            ChangeLevel("MainMenu");
        }

        public void OpenSideScrollGame()
        {
            ChangeLevel("SideScroller");
        }

        public void OpenBallGame()
        {
            ChangeLevel("BallGame");
        }

        private void ChangeLevel(string newLevel)
        {
            SceneManager.LoadScene(newLevel);
        }

    }
}