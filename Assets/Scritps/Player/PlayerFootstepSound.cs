using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

namespace Player
{
    //스크립트 개요 작성
    public class PlayerFootstepSound : MonoBehaviour
    {
        #region Invisible Variables
        private PlayerPhysic playerPhysic;
        private PlayerStateCTRL playerStateCTRL;

        /// <summary>
        /// 현재 바닥 재질에 따른 발소리
        /// </summary>
        private PlayerFootstepAudioSource currentSound = null;

        /// <summary>
        /// 현재 바닥 재질
        /// </summary>
        private string currentFloorMaterial;
        #endregion

        #region Visible Variables
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private PlayerFootstepSoundSettingData setting;        

        /// <summary>
        /// 현재 바닥 재질에 따른 발소리 모음
        /// </summary>
        [Header("SoundSources")]
        [SerializeField] private PlayerFootstepSoundDatabase playerFootstepSoundDatabase;
        #endregion

        #region Properties
        private string CurrentFloorMaterial
        {
            get => currentFloorMaterial;
            set
            {
                if (value == currentFloorMaterial) return;
                currentFloorMaterial = value;
                ChangedFloorMeterial();
            }
        }
        #endregion

        #region Unity Event Methods
        //이벤트 메소드 작성
        private void Awake()
        {
            playerPhysic = GetComponent<PlayerPhysic>();
            playerStateCTRL = GetComponent<PlayerStateCTRL>();
            playerPhysic.landEvent += PlayLandSound;

            StartCoroutine(PlayMoveSound());
        }

        private void Start()
        {
            SetInputSystem();
        }

        private void Update()
        {
            RaycastHit hit;
            Physics.SphereCast(playerPhysic.GroundSphereOffset, playerPhysic.SafeRadius, Vector3.down, out hit, 0.3f);
            if (hit.transform != null)
                CurrentFloorMaterial = hit.transform.gameObject.tag;
        }
        #endregion

        #region Methods
        private void SetInputSystem()
        {
            //점프 키 이벤트
            PlayerInput.input.fpc.Player.Jump.performed += val => {
                if(playerStateCTRL.postureState == PlayerPostureState.Standing && playerPhysic.IsGround)
                    PlayJumpSound();
            };
        }

        private void ChangedFloorMeterial()
        {
            foreach (var item in playerFootstepSoundDatabase.soundDatas) {
                if (item.materiallName == currentFloorMaterial) {
                    currentSound = item;
                    return;
                }
            }

            currentFloorMaterial = null;
        }

        private IEnumerator PlayMoveSound()
        {
            WaitForSeconds walkDelay = new WaitForSeconds(setting.walkSoundDelay);
            WaitForSeconds moveDelay = new WaitForSeconds(setting.moveSoundDelay);
            WaitForSeconds runSoundDelay = new WaitForSeconds(setting.runSoundDelay);
            WaitForSeconds crouchSoundDelay = new WaitForSeconds(setting.crouchSoundDelay);

            while (true) {
                if (!playerPhysic.IsGround) {
                    yield return null;
                    continue;
                }
                if(playerStateCTRL.moveState != PlayerMoveState.Stop && playerStateCTRL.postureState == PlayerPostureState.Crouch) {
                    audioSource.PlayOneShot(currentSound.walk[Random.Range(0, currentSound.walk.Length - 1)], setting.crouchVolume);
                    yield return crouchSoundDelay;
                    continue;
                }
                switch (playerStateCTRL.moveState) {
                    case PlayerMoveState.Stop:
                        yield return null;
                        break;
                    case PlayerMoveState.Walk:
                        audioSource.PlayOneShot(currentSound.walk[Random.Range(0, currentSound.walk.Length - 1)], setting.walkVolume);
                        yield return walkDelay;
                        break;
                    case PlayerMoveState.Move:
                        audioSource.PlayOneShot(currentSound.walk[Random.Range(0, currentSound.walk.Length - 1)], setting.moveVolume);
                        yield return moveDelay;
                        break;
                    case PlayerMoveState.Run:
                        audioSource.PlayOneShot(currentSound.run[Random.Range(0, currentSound.run.Length - 1)], setting.runVolume);
                        yield return runSoundDelay;
                        break;
                    default:
                        break;
                }
            }
        }

        private void PlayJumpSound()
        {
            if (currentFloorMaterial != null)
                audioSource.PlayOneShot(currentSound.jumpStart[Random.Range(0, currentSound.jumpStart.Length - 1)]);
        }

        private void PlayLandSound()
        {
            if(currentFloorMaterial != null)
                audioSource.PlayOneShot(currentSound.jumpEnd[Random.Range(0, currentSound.jumpEnd.Length - 1)]);
        }
        #endregion

    }
}
