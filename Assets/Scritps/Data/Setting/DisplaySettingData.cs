using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Data;

[System.Serializable]
public class DisplaySettingData
{
    public FullScreenMode screenMode = FullScreenMode.FullScreenWindow;
    public int resolutionX = 1920;
    public int resolutionY = 1080;
    public int resolutionDropDownValue = 0;

    public DisplaySettingData(DisplaySettingData data)
    {
        screenMode = data.screenMode;
        resolutionX = data.resolutionX;
        resolutionY = data.resolutionY;
        resolutionDropDownValue = data.resolutionDropDownValue;
    }

    public void SetResolution(Vector2Int resolution)
    {
        resolutionX = resolution.x;
        resolutionY = resolution.y;
    }
}
