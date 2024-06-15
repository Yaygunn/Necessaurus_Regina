using UnityEngine;

namespace Manager.DontDestroy
{
    public class DontDestroy : MonoBehaviour
    {
        private static DontDestroy instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}
