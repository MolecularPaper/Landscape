using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Data;

//스크립트 개요 작성
public class SoundController : MonoBehaviour
{
    #region Variables
    [SerializeField] private AudioSource globalSE;
    private static AudioSource bgmAudioSource;
    private static List<AudioSource> seAudioSources;
    #endregion

    #region Unity Event Methods
    //이벤트 메소드 작성
    private void Awake()
    {
        bgmAudioSource = GetComponent<AudioSource>();
        seAudioSources = FindObjectsOfType<AudioSource>().ToList();
        seAudioSources.Remove(bgmAudioSource);
    }

    [ContextMenu("Change Sound")]
    public static void ChangeVolume(SoundSettingData soundSettingData)
    {
        bgmAudioSource.volume = soundSettingData.masterVolume * soundSettingData.bgmVolume * 0.2f;
        foreach (var item in seAudioSources) {
            item.volume = soundSettingData.masterVolume * soundSettingData.seVolume;
        }
    }

    public void PlayGlobalSE(AudioClip audioClip) => globalSE.PlayOneShot(audioClip);
    #endregion

}
