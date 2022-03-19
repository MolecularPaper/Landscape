using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Data;

[System.Serializable]
public class GeneralSettingData
{
    public float mouseSensitivity = 20;
    public bool xAxisInversion = false;
    public bool yAxisInversion = false;
    public bool fpsCounterVisible = false;

    public GeneralSettingData(GeneralSettingData data)
    {
        mouseSensitivity = data.mouseSensitivity;
        xAxisInversion = data.xAxisInversion;
        yAxisInversion = data.yAxisInversion;
        fpsCounterVisible = data.fpsCounterVisible;
    }
}
