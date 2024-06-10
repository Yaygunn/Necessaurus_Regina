using System;
using UnityEngine;

public static class EventHub 
{
    public static event Action<float> Event_MoveSpeed;
    public static void MoveSpeed(float speed)
    {
        Event_MoveSpeed?.Invoke(speed);
    }
}
