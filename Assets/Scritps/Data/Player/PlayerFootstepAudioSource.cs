using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class PlayerFootstepAudioSource
    {
        /// <summary>
        /// ���̾ ����� ���� �̸��̶� ���ƾ���
        /// </summary>
        public string materiallName;
        public AudioClip[] walk;
        public AudioClip[] run;
        public AudioClip[] jumpStart;
        public AudioClip[] jumpEnd;
    }
}
