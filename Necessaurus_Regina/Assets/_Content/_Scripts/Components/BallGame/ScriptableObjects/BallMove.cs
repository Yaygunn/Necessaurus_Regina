using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball Move", menuName = "Scriptables/BallGame/BallMove", order = 1)]

public class BallMove : ScriptableObject
{
    public string MoveName;
    public int MovePoints;
    public string MoveDescription;
    public bool ShowNameOnScore;
}
