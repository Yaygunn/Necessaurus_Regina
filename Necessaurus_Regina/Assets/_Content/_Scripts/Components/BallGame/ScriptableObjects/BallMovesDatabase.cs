using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallMovesDatabase", menuName = "Scriptables/BallGame/BallMovesDatabase", order = 2)]
public class BallMovesDatabase : ScriptableObject
{
    public List<BallMove> BallMoves;
}
