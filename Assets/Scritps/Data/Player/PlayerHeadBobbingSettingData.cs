using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Player Head Bobbing Setting Data", menuName = "Player Head Bobbing Setting Data")]
public class PlayerHeadBobbingSettingData : ScriptableObject
{
    public float walkingBobbingSpeed = 14f;
    public float moveBobbingSpeed = 14f;
    public float runBobbingSpeed = 14f;
    public float crouchBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;
}
