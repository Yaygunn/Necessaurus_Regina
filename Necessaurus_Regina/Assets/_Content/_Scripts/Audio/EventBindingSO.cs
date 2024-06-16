using FMODUnity;
using UnityEngine;

namespace Audio.Events
{
    [CreateAssetMenu(fileName = "SoundEventRef", menuName = "Scriptables/SoundEvents")]
    public class EventBindingSO : ScriptableObject
    {
        [field:SerializeField] public EventReference Jump { get; private set; }

        [field:SerializeField] public EventReference BirdHit { get; private set; }

        [field:SerializeField] public EventReference WallHit { get; private set; }

        [field:SerializeField] public EventReference FloorHit { get; private set; }

        [field:SerializeField] public EventReference BallKick { get; private set; }

        [field:SerializeField] public EventReference Music { get; private set; }
    }
}