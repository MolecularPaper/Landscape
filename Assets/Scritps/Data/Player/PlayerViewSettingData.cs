using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerViewSettingData", menuName = "PlayerViewSettingData", order = 2)]
public class PlayerViewSettingData : ScriptableObject
{
    /// <summary>
    /// 시점 x축 반전 (상하)
    /// </summary>
    public bool xAxisInversion;

    /// <summary>
    /// 시점 y축 반전 (상하)
    /// </summary>
    public bool yAxisInversion;

    /// <summary>
    /// 시점 x축의 회전 민감도 (상하)
    /// </summary>
    [Space(10)]
    public float xAxisSensitivity;

    /// <summary>
    /// 시점 y축의 회전 민감도 (좌우)
    /// </summary>
    public float yAxisSensitivity;

    /// <summary>
    /// 시점 x축의 회전(상하) 최대 각도
    /// </summary>
    [Space(10)]
    [Range(0, 90)] public float maxAngleX;

    /// <summary>
    /// 시점 x축의 회전(상하) 최소 각도
    /// </summary>
    [Range(0, -90)] public float minAngleX;
}
