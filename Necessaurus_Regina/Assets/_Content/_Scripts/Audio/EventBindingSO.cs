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

        [field: SerializeField] public EventReference BallHeadHit { get; private set; }

        [field: SerializeField] public EventReference BallChestHit { get; private set; }


        [field: SerializeField] public EventReference DogHit { get; private set; }

        [field: SerializeField] public EventReference ChairHit { get; private set; }

        [field: SerializeField] public EventReference FlipFlopHit { get; private set; }


        [field: SerializeField] public EventReference UIHover { get; private set; }
        [field: SerializeField] public EventReference UIBack { get; private set; }
        [field: SerializeField] public EventReference UIOK { get; private set; }


        [field:SerializeField] public EventReference Music { get; private set; }
    }
}