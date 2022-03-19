using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Manager;

namespace UICTRL
{
    //UI 활성화, 비활성화 관리
    public class UIManager : MonoBehaviour
    {
        #region Variables
        public static UIManager uIManager = null;

        [Header("UI")]
        [SerializeField] private GameObject InventoryUI;
        [SerializeField] private GameObject settingUI;
        [SerializeField] private GameObject confirmUI;
        [SerializeField] private GameObject menuUI;
        [SerializeField] private GameObject fpsCounter;
        [SerializeField] private CanvasGroup fade;
        [SerializeField] private Image effectImage;

        #endregion

        #region Properties

        #endregion

        #region Unity Event Methods
        private void Awake()
        {
            uIManager = this;
        }


        private void Start()
        {
            StartCoroutine(Fade(false));

            if (SceneManager.GetActiveScene().name != "Title") SetInputSystem();
            else SetTitleInputSystem();
        }
        #endregion

        #region Methods
        private void SetInputSystem()
        {
            PlayerInput.input.fpc.UI.Inventory.performed += val => {
                UIOnOff(InventoryUI, !InventoryUI.activeSelf);
            };
            PlayerInput.input.fpc.UI.Cancel.performed += val => {
                if (!InventoryUI.activeSelf && !settingUI.activeSelf && !menuUI.activeSelf) {
                    UIOnOff(menuUI, true);
                }
                else if (settingUI.activeSelf) {
                    FindObjectOfType<SettingManager>().SaveSettingData();
                    UIOnOff(menuUI, true);
                }
                else UIOnOff(menuUI, false);
            };
        }

        private void SetTitleInputSystem()
        {
            PlayerInput.input.fpc.UI.Cancel.performed += val => {
                if (settingUI.activeSelf) {
                    settingUI.SetActive(false);
                    FindObjectOfType<SettingManager>().SaveSettingData();
                }
            };
        }

        public void UIOnOff(GameObject ui, bool active)
        {
            if (active) {
                DisableAllUI();
            }

            ui.SetActive(active);
            CursorManager.CusorLock(!active);
        }

        public void DisableAllUI()
        {
            if(SceneManager.GetActiveScene().name != "Title") {
                InventoryUI.SetActive(false);
                menuUI.SetActive(false);
                confirmUI.SetActive(false);
            }
            settingUI.SetActive(false);
        }

        public IEnumerator Fade(bool isFadeIn)
        {
            float timer = 0f;
            while (timer <= 1f) {
                yield return null;
                timer += Time.unscaledTime * 3f;
                fade.alpha = isFadeIn ? Mathf.Lerp(0f, 1f, timer) : Mathf.Lerp(1f, 0f, timer);
            }

            if (!isFadeIn)
                fade.gameObject.SetActive(false);
        }

        public void SetEffectUI(Sprite sprite)
        {
            effectImage.sprite = sprite;
            effectImage.gameObject.SetActive(true);
        }

        public void DisableEffectUI()
        {
            effectImage.sprite = null;
            effectImage.gameObject.SetActive(false);
        }

        public void FpsCounterVisible(bool active) => fpsCounter.SetActive(active);
        #endregion
    }
}
