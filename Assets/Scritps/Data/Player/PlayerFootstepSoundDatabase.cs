using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Player Footstep Sound Database", menuName = "Player Footstep Sound Database")]
    public class PlayerFootstepSoundDatabase : ScriptableObject
    {
        public List<PlayerFootstepAudioSource> soundDatas = new List<PlayerFootstepAudioSource>();
    }

}