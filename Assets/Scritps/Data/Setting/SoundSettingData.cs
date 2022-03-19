using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager;
using Data;

namespace Data
{
    [System.Serializable]
    public class SoundSettingData
    {
        public float masterVolume = 1.0f;
        public float bgmVolume = 1.0f;
        public float seVolume = 1.0f;

        

        public SoundSettingData(SoundSettingData data)
        {
            masterVolume = data.masterVolume;
            bgmVolume = data.bgmVolume;
            seVolume = data.seVolume;
        }
    }
}