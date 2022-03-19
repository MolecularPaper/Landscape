using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoUI : MonoBehaviour
{
    public static InfoUI infoUI = null;

    [SerializeField] private TextMeshProUGUI tmp_text;
    [SerializeField] private Image image;

    [SerializeField] private float showTime;
    [SerializeField] private float fadeInDelta;
    [SerializeField] private float fadeOutDelta;

    private bool isPlaying;
    private float alpha = 0f;

    private void Awake()
    {
        if(infoUI == null) infoUI = this;
    }

    // Update is called once per frame
    void Update()
    {
        tmp_text.alpha = alpha;
        SetImageAlpha(alpha);
    }

    public void ShowInfo(string text)
    {
        tmp_text.text = text;
        Task.Run(ShowInfoAsync);
    }

    private async void ShowInfoAsync()
    {
        if (isPlaying) return;

        isPlaying = true;

        while (alpha != 1) {
            alpha = Mathf.MoveTowards(alpha, 1, fadeInDelta);
            await Task.Delay(10);
        }

        await Task.Delay((int)(showTime * 1000));

        while (alpha != 0) {
            alpha = Mathf.MoveTowards(alpha, 0, fadeOutDelta);
            await Task.Delay(10);
        }

        isPlaying = false;
    }

    private void SetImageAlpha(float alpha)
    {
        Color color = image.color;
        color.a = alpha;

        image.color = color;
    }
}
