using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerViewSettingData", menuName = "PlayerViewSettingData", order = 2)]
public class PlayerViewSettingData : ScriptableObject
{
    /// <summary>
    /// ���� x�� ���� (����)
    /// </summary>
    public bool xAxisInversion;

    /// <summary>
    /// ���� y�� ���� (����)
    /// </summary>
    public bool yAxisInversion;

    /// <summary>
    /// ���� x���� ȸ�� �ΰ��� (����)
    /// </summary>
    [Space(10)]
    public float xAxisSensitivity;

    /// <summary>
    /// ���� y���� ȸ�� �ΰ��� (�¿�)
    /// </summary>
    public float yAxisSensitivity;

    /// <summary>
    /// ���� x���� ȸ��(����) �ִ� ����
    /// </summary>
    [Space(10)]
    [Range(0, 90)] public float maxAngleX;

    /// <summary>
    /// ���� x���� ȸ��(����) �ּ� ����
    /// </summary>
    [Range(0, -90)] public float minAngleX;
}
