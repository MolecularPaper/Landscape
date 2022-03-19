using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Player;
using UICTRL;
using TMPro;
using Data;

namespace Manager
{
    //게임 세팅 관리자
    public class SettingManager : MonoBehaviour
    {
        #region Variables
        [Header("General Setting UI")]
        [SerializeField] private TMP_InputField mouseSensitivityInput;
        [SerializeField] private Slider mouseSensitivitySlider;

        [Space(10)]
        [SerializeField] private Toggle horizontalInversionToggle;
        [SerializeField] private Toggle verticalnversionToggle;

        [Space(10)]
        [SerializeField] private Toggle fpsCounterToggle;

        [Header("Display Setting UI")]
        [SerializeField] private TMP_Dropdown screenModeDropDown;
        [SerializeField] private TMP_Dropdown resolutionDropDown;

        [Header("Sound Setting UI")]
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider bgmVolumeSlider;
        [SerializeField] private Slider seVolumeSlider;
        #endregion

        #region Properties
        private PlayerViewCTRL playerViewCTRL { get; set; }

        //Datas
        public GeneralSettingData generalSettingData;
        public GraphicSettingData graphicSettingData;
        public DisplaySettingData displaySettingData;
        public SoundSettingData soundSettingData;
        #endregion

        #region Unity Event Methods
        private void Awake()
        {
            playerViewCTRL = FindObjectOfType<PlayerViewCTRL>();
        }

        private void Start()
        {
            GameDataManager.gdm.LoadSettingData(this);

            LoadSettingUI();
            LoadGlobalSetting();

            if (SceneManager.GetActiveScene().name != "Title") LoadInGameSetting();
        }

        #endregion

        #region Methods
        private void LoadSettingUI()
        {
            //Display
            screenModeDropDown.value = (int)displaySettingData.screenMode;
            resolutionDropDown.value = displaySettingData.resolutionDropDownValue;

            //General
            mouseSensitivityInput.text = generalSettingData.mouseSensitivity.ToString();
            mouseSensitivitySlider.value = generalSettingData.mouseSensitivity;

            horizontalInversionToggle.isOn = generalSettingData.xAxisInversion;
            verticalnversionToggle.isOn = generalSettingData.yAxisInversion;

            fpsCounterToggle.isOn = generalSettingData.fpsCounterVisible;

            //Sound
            masterVolumeSlider.value = soundSettingData.masterVolume;
            bgmVolumeSlider.value = soundSettingData.bgmVolume;
            seVolumeSlider.value = soundSettingData.seVolume;
        }

        private void LoadGlobalSetting()
        {
            //Display - Screen Mode, Resolution
            Screen.SetResolution(displaySettingData.resolutionX, displaySettingData.resolutionY, displaySettingData.screenMode);

            //Sound
            SoundController.ChangeVolume(soundSettingData);
        }

        private void LoadInGameSetting()
        {
            if(playerViewCTRL != null) playerViewCTRL.SetSetting(generalSettingData);
        }

        public void SaveSettingData() => GameDataManager.gdm.SaveSettingData(this);

        #region General
        public void ChangeMouseSensitivity(GameObject gameObject)
        {
            if(gameObject.GetComponent<TMP_InputField>() != null) {
                TMP_InputField InputField = gameObject.GetComponent<TMP_InputField>();

                if (100f < float.Parse(InputField.text)) {
                    InputField.text = "100";
                }
                else if (1 > float.Parse(InputField.text)) {
                    InputField.text = "1";
                }

                generalSettingData.mouseSensitivity = float.Parse(InputField.text);
                mouseSensitivitySlider.value = generalSettingData.mouseSensitivity;
            }
            else {
                generalSettingData.mouseSensitivity = gameObject.GetComponent<Slider>().value;
                mouseSensitivityInput.text = generalSettingData.mouseSensitivity.ToString();
            }

            if (playerViewCTRL != null) playerViewCTRL.SetSetting(generalSettingData);
        }

        public void ChangeHorizontalInversion()
        {
            generalSettingData.yAxisInversion = horizontalInversionToggle.isOn;
            if (playerViewCTRL != null) playerViewCTRL.SetSetting(generalSettingData);
        }

        public void ChangeVerticalInversion()
        {
            generalSettingData.xAxisInversion = verticalnversionToggle.isOn;
            if (playerViewCTRL != null) playerViewCTRL.SetSetting(generalSettingData);
        }

        public void ChangeFPSCounterVisible()
        {
            generalSettingData.fpsCounterVisible = fpsCounterToggle.isOn;
            UIManager.uIManager.FpsCounterVisible(fpsCounterToggle.isOn);
        }

        #endregion

        #region Display
        public void ChangeScreenMode()
        {
            displaySettingData.screenMode = (FullScreenMode)screenModeDropDown.value;
            Screen.SetResolution(displaySettingData.resolutionX, displaySettingData.resolutionY, displaySettingData.screenMode);
        }

        public void ChangeResolution()
        {
            displaySettingData.resolutionDropDownValue = resolutionDropDown.value;
            switch (resolutionDropDown.value) {
                case 0:
                    displaySettingData.SetResolution(new Vector2Int(960, 540));
                    break;
                case 1:
                    displaySettingData.SetResolution(new Vector2Int(1280, 720));
                    break;
                case 2:
                    displaySettingData.SetResolution(new Vector2Int(1600, 900));
                    break;
                case 3:
                    displaySettingData.SetResolution(new Vector2Int(1920, 1080));
                    break;
                case 4:
                    displaySettingData.SetResolution(new Vector2Int(2560, 1440));
                    break;
                case 5:
                    displaySettingData.SetResolution(new Vector2Int(3840, 2160));
                    break;
            }

            Screen.SetResolution(displaySettingData.resolutionX, displaySettingData.resolutionY, displaySettingData.screenMode);
        }

        #endregion

        #region Graphic

        #endregion

        #region Sound
        private void ChangeAllVolume()
        {
            soundSettingData.masterVolume = masterVolumeSlider.value;
            soundSettingData.bgmVolume = bgmVolumeSlider.value;
            soundSettingData.seVolume = seVolumeSlider.value;
            SoundController.ChangeVolume(soundSettingData);
        }

        public void ChangeMasterVolume()
        {
            soundSettingData.masterVolume = masterVolumeSlider.value;
            SoundController.ChangeVolume(soundSettingData);
        }

        public void ChangeBGMVolume()
        {
            soundSettingData.bgmVolume = bgmVolumeSlider.value;
            SoundController.ChangeVolume(soundSettingData);
        }

        public void ChangeSEVolume()
        {
            soundSettingData.seVolume = seVolumeSlider.value;
            SoundController.ChangeVolume(soundSettingData);
        }
        #endregion        

        #endregion
    }
}
