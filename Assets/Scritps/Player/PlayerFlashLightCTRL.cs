using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashLightCTRL : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform hand;
    [SerializeField] private float turnLerp;

    [Space(10)]
    [SerializeField] private Light flashLight;
    [SerializeField] private float lightIntensity;
    #endregion

    #region Unity Event Methods
    private void Start() => SetInputSystem();

    private void OnEnable()
    {
        flashLight.transform.position = hand.position;
        flashLight.transform.rotation = hand.rotation;
        flashLight.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        flashLight.intensity = 0.0f;
        flashLight.gameObject.SetActive(false);
    }

    void Update()
    {
        if (flashLight.intensity != lightIntensity) {
            flashLight.intensity = Mathf.MoveTowards(flashLight.intensity, lightIntensity, 0.01f);
        }

        flashLight.transform.position = Vector3.Lerp(flashLight.transform.position, hand.position, Time.deltaTime * turnLerp);
        flashLight.transform.rotation = Quaternion.Lerp(flashLight.transform.rotation, hand.rotation, Time.deltaTime * turnLerp);
    }
    #endregion

    #region Methods
    /// <summary>
    /// InputSystem의 각 키 이벤트마다 실행할 메소드 등록
    /// </summary>
    private void SetInputSystem()
    {
        PlayerInput.input.fpc.Player.FlashLight.performed += val => {
            flashLight.enabled = !flashLight.enabled;
        };
    }
    #endregion
}
