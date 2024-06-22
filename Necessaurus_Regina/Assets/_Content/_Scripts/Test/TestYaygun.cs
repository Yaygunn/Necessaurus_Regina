using FMODUnity;
using SideScroller.Components.ScrollObject;
using UnityEngine;
using Manager.ObjectPool;

namespace Test.Yaygun
{
    public class TestYaygun : MonoBehaviour
    {

        [SerializeField] private float speed;

        private void Update()
        {
            EventHub.ParallaxMove(speed * Time.deltaTime);
        }

    }
}
