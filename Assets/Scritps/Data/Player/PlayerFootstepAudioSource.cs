using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class PlayerFootstepAudioSource
    {
        /// <summary>
        /// 레이어에 등록한 재질 이름이랑 같아야함
        /// </summary>
        public string materiallName;
        public AudioClip[] walk;
        public AudioClip[] run;
        public AudioClip[] jumpStart;
        public AudioClip[] jumpEnd;
    }
}
