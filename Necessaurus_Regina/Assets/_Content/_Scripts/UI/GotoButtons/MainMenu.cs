using Manager.LevelChanger;
using UnityEngine;

namespace UI.GoBackMainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public void GoMainMenu()
        {
            LevelChanger.Instance.OpenMainMenu();
        }
        
        public void GoSidescroller()
        {
            LevelChanger.Instance.OpenSideScrollGame();
        }
        
        public void GoBallgame()
        {
            LevelChanger.Instance.OpenBallGame();
        }
    }
}
