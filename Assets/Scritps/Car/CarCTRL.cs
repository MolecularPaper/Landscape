using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Player;

[RequireComponent(typeof(AudioSource))]
public class CarCTRL : MonoBehaviour
{
    [SerializeField] private Transform steer;
    [SerializeField] private WheelCollider FLWheelCollider;
    [SerializeField] private WheelCollider FRWheelCollider;
    [SerializeField] private WheelCollider BLWheelCollider;
    [SerializeField] private WheelCollider BRWheelCollider;
    [SerializeField] private Transform FLWheel;
    [SerializeField] private Transform FRWheel;
    [SerializeField] private Light leftLight;
    [SerializeField] private Light rightLight;
    [SerializeField] private Light panelLight;

    private Transform[] movePoint;

    [Header("Sound")]
    [SerializeField] private AudioClip driveSound;
    [SerializeField] private AudioClip doorOpenSound;
    [SerializeField] private AudioClip doorCloseSound;

    [Header("Setting")]
    [SerializeField] private Vector2 steerAngleRange;
    [SerializeField] private Vector2 mortorTorqueRange;
    [SerializeField] private float maxBreakTorque;
    [SerializeField] private Transform carExit;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject cam;

    [Header("Events")]
    [SerializeField] private UnityEvent exitEvent;

    [Header("Info")]
    [ShowOnly, SerializeField] private float steerAngle;
    [ShowOnly, SerializeField] private float mortorTorque;
    [ShowOnly, SerializeField] private float breakTorque;

    private Animator animator;
    private AudioSource audioSource;

    public float SteerRatio => (steerAngleRange.x - steerAngleRange.y) / 30;

    public float SteerAngle
    {
        get => steerAngle;
        set
        {
            if (value < steerAngleRange.x) {
                steerAngle = steerAngleRange.x;
            }
            else if(value > steerAngleRange.y) {
                steerAngle = steerAngleRange.y;
            }
            else {
                steerAngle = value;
            }
        }
    }

    public float MortorTorque
    {
        get => mortorTorque;
        set
        {
            if (value < mortorTorqueRange.x) {
                mortorTorque = mortorTorqueRange.x;
            }
            else if (value > mortorTorqueRange.y) {
                mortorTorque = mortorTorqueRange.y;
            }
            else {
                mortorTorque = value;
            }
        }
    }

    public float BreakTorque
    {
        get => breakTorque;
        set
        {
            if (value > maxBreakTorque) {
                breakTorque = maxBreakTorque;
            }
            else {
                breakTorque = value;
            }
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = driveSound;
    }

    // Update is called once per frame
    void Update()
    {
        FLWheelCollider.steerAngle = -steerAngle / SteerRatio;
        FRWheelCollider.steerAngle = -steerAngle / SteerRatio;
        SetWheel(FLWheelCollider);
        SetWheel(FRWheelCollider);
        SetWheel(BLWheelCollider);
        SetWheel(BRWheelCollider);
        ApplyLocalPositionToVisuals();
        SetSound();
    }

    private void SetSound()
    {
        audioSource.pitch = Mathf.MoveTowards(audioSource.pitch, 1.3f + (mortorTorque / mortorTorqueRange.y) * 2, 0.01f);

        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
    }


    private void SetWheel(WheelCollider wheelCollider)
    {
        wheelCollider.motorTorque = mortorTorque;
        wheelCollider.brakeTorque = breakTorque;
    }

    public IEnumerator StopCar()
    {
        while (true) {
            MortorTorque = Mathf.MoveTowards(MortorTorque, 0, 100f);
            SteerAngle = Mathf.MoveTowards(SteerAngle, 0, 0.7f);

            if (MortorTorque == 0 && SteerAngle == 0) {
                break;
            }

            yield return null;
        }
    }

    public IEnumerator TrunOffLight()
    {
        while (panelLight.intensity != 0.0f) {
            leftLight.intensity = Mathf.MoveTowards(leftLight.intensity, 0, 0.1f);
            rightLight.intensity = Mathf.MoveTowards(rightLight.intensity, 0, 0.1f);
            panelLight.intensity = Mathf.MoveTowards(panelLight.intensity, 0, 0.1f);
            yield return null;
        }
    }

    public IEnumerator TrunOffEngine()
    {
        while (audioSource.volume != 0.0f) {
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, 0.0f, 0.01f);
            yield return null;
        }

        audioSource.loop = false;
        audioSource.clip = null;
        audioSource.volume = 1.0f;
    }

    public void ExitTrigger() => animator.SetTrigger("ExitCar");
    public void ExitCar()
    {
        PlayerViewCTRL playerViewCTRL = player.GetComponentInChildren<PlayerViewCTRL>();
        playerViewCTRL.CurrentYAngle = cam.transform.eulerAngles.y;
        playerViewCTRL.CurrentXAngle = 0;
        player.position = carExit.position;
        player.gameObject.SetActive(true);
        cam.SetActive(false);
        exitEvent.Invoke();
    }

    public void DoorOpen() => audioSource.PlayOneShot(doorOpenSound);
    public void DoorClose() => audioSource.PlayOneShot(doorCloseSound);

    public void ApplyLocalPositionToVisuals()
    {
        Vector3 FLPos;
        Quaternion FLRot;

        Vector3 FRPos;
        Quaternion FRRot;

        steer.localRotation = Quaternion.Euler(22.116f, 0, -steerAngle);

        FLWheelCollider.GetWorldPose(out FLPos, out FLRot);
        FRWheelCollider.GetWorldPose(out FRPos, out FRRot);

        FLWheel.transform.position = FLPos;
        FLWheel.transform.rotation = FLRot;

        FRWheel.transform.rotation = FRRot;
        FRWheel.transform.rotation = FRRot;
    }
}
