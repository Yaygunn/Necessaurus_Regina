using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundComp : MonoBehaviour
{
    public void PlayerStepped()
    {
        EventHub.PlayerStep();
    }
}
