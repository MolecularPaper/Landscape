using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Door Sound Data", menuName = "Door Sound Data")]
    public class DoorSoundData : ScriptableObject
    {
        public AudioClip doorOpenSound;
        public AudioClip doorCloseSound;
        public AudioClip doorUnlockSound;
        public AudioClip doorKnockingSound;

        [Space(10)]
        public float doorOpenVolume;
        public float doorCloseVolume;
        public float doorUnlockVolume;
        public float doorKnockingVolume;
    }
}
