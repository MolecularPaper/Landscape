using System.Collections;
using System.Collections.Generic;
using UICTRL;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Manager
{
    //스크립트 개요 작성
    public class GameManager : MonoBehaviour
    {
        #region Properties
        public static GameManager gm { get; private set; }

        public UnityEvent startEvent;
        #endregion

        #region Unity Event Methods
        private void Awake()
        {
            gm = this;

            Application.targetFrameRate = 240;
        }

        private void Start()
        {
            startEvent.Invoke();
        }

        private void OnApplicationQuit()
        {
            GameDataManager.gdm.saveData.Invoke();
        }
        #endregion

        #region Methods
        public void GameStart() => ChangeStage(GameDataManager.gdm.startSceneName);

        public void QuitGame() => Application.Quit();

        public void GoTitle()
        {
            GameDataManager.gdm.saveData.Invoke();
            SceneManager.LoadScene("Title");
        }

        public void ChangeStage(string changeSceneName)
        {
            UnityAction saveData = GameDataManager.gdm.saveData;
            if (saveData != null) saveData.Invoke();

            StartCoroutine(FadeAndLoad(changeSceneName));
        }

        public IEnumerator FadeAndLoad(string changeSceneName)
        {
            yield return StartCoroutine(UIManager.uIManager.Fade(true));
            SceneManager.LoadScene(changeSceneName);
        }

        public void ReloadStage()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion        
    }
}
