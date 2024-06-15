using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager.LevelChanger
{
    public class LevelChanger : MonoBehaviour
    {
        [SerializeField] private bool _reload;

        private bool _reloadEnabled = false;

        void Update()
        {
            if (_reload && !_reloadEnabled)
            {
                _reloadEnabled = true;
                SceneManager.LoadScene(0);
            }
        }
    }
}