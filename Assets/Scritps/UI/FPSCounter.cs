using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Utility
{
    public class FPSCounter : MonoBehaviour
    {
        private TextMeshProUGUI countText;

        private float fps;

        private void Awake()
        {
            countText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            StartCoroutine(UpdateFPS());
        }

        private void OnDisable()
        {
            StopCoroutine(UpdateFPS());
        }

        private IEnumerator UpdateFPS()
        {
            while (true) {
                countText.text = $"FPS: {Mathf.Round(fps = 1.0f / Time.deltaTime)}";
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}