using FMODUnity;
using UnityEngine;

namespace Test.Yaygun
{
    public class TestYaygun : MonoBehaviour
    {
        [SerializeField] EventReference _eventTest;
        void Start()
        {
            RuntimeManager.PlayOneShot(_eventTest);
        }

       
    }
}
