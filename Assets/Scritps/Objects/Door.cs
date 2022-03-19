using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

[System.Serializable]
public class DoorData
{
    public bool canOpen = true;
    public bool doorOpen = false;
    public bool doorLocked = false;
}

public class Door : MonoBehaviour
{
    #region Variables
    private Animator animator;
    public DoorData doorData = new DoorData();

    public string doorKeyItemCode;

    [Header("Sound")]
    [SerializeField]
    public DoorSoundData sounds;
    private AudioSource audioSource;
    #endregion

    #region Unity Event Mehtods
    private void Awake()
    {
        try {
            audioSource.GetComponent<AudioSource>();
        }
        catch (System.Exception) {
            try {
                audioSource = GetComponentInChildren<AudioSource>();
            }
            catch (System.Exception) { }
        }
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ApplyAnimator();
    }
    #endregion

    #region Methods

    public void SetData(DoorData doorData)
    {
        this.doorData.doorOpen = doorData.doorOpen;
        this.doorData.doorLocked = doorData.doorLocked;
    }

    public void Interection()
    {
        doorData.doorOpen = !doorData.doorOpen;
        ApplyAnimator();
    }

    public void DoorOpen()
    {
        doorData.doorOpen = true;
        ApplyAnimator();
    }

    public void DoorClose()
    {
        doorData.doorOpen = false;
        ApplyAnimator();
    }

    public void DoorOpenSound() => audioSource.PlayOneShot(sounds.doorOpenSound, sounds.doorOpenVolume);

    public void DoorCloseSound() => audioSource.PlayOneShot(sounds.doorCloseSound, sounds.doorCloseVolume);
    public void DoorKnockingeSound() => audioSource.PlayOneShot(sounds.doorKnockingSound, sounds.doorKnockingVolume);

    public void DoorLock()
    {
        doorData.doorOpen = false;
        doorData.doorLocked = true;
        ApplyAnimator();
    }

    public void DoorUnLock()
    {
        doorData.doorLocked = false;
        animator.SetBool("DoorLocked", doorData.doorLocked);
        audioSource.PlayOneShot(sounds.doorUnlockSound, 0.3f);
    }

    public void ApplyAnimator()
    {
        animator.SetBool("DoorLocked", doorData.doorLocked);
        animator.SetBool("DoorOpen", doorData.doorOpen && !doorData.doorLocked);
    }

    #endregion
}
