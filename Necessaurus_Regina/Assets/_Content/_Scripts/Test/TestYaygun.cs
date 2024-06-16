using FMODUnity;
using SideScroller.Components.ScrollObject;
using UnityEngine;
using Manager.ObjectPool;

namespace Test.Yaygun
{
    public class TestYaygun : MonoBehaviour
    {      
        [SerializeField] bool menu;
        [SerializeField] bool Scroller;
        [SerializeField] bool Ball;


        private void Update()
        {
            if(menu)
            {
                menu = false;
                EventHub.StartMenu();
            }
            if(Scroller)
            {
                Scroller = false;
                EventHub.StartScrollerLevel();
            }
            if (Ball)
            {
                Ball = false;
                EventHub.StartBallGameLevel();
            }
        }

    }
}
