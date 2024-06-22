using UnityEngine;

namespace Component.ObstacleType
{
    public enum EObsType { FlipFlop, Dog, Chair}
    public class ObstacleType : MonoBehaviour
    {
        [field:SerializeField] public EObsType type;
    }
}
