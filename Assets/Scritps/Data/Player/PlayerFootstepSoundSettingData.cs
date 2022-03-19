using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Player Footstep Sound Setting", menuName = "Player Footstep Sound Setting")]
public class PlayerFootstepSoundSettingData : ScriptableObject
{
    public float walkSoundDelay;
    public float moveSoundDelay;
    public float runSoundDelay;
    public float crouchSoundDelay;

    [Space(5)]
    public float walkVolume;
    public float moveVolume;
    public float runVolume;
    public float crouchVolume;
}
