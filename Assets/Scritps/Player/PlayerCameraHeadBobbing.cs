using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

namespace Player
{
    //스크립트 개요 작성
    public class PlayerCameraHeadBobbing : MonoBehaviour
    {
        #region Variables
        [SerializeField] private PlayerHeadBobbingSettingData setting;
        private PlayerStateCTRL playerStateCTRL;
        private new Transform camera;

        private float defaultPosY = 0;
        private float timer = 0;
        #endregion

        #region Properties
        //프로퍼티 작성
        #endregion

        #region Unity Event Methods
        void Awake()
        {
            playerStateCTRL = GetComponent<PlayerStateCTRL>();

            camera = Camera.main.transform;
            defaultPosY = camera.localPosition.y;
        }

        // Update is called once per frame
        void Update()
        {
            if(playerStateCTRL.moveState == PlayerMoveState.Stop) {
                //Idle
                timer = 0;
                camera.localPosition = new Vector3(camera.localPosition.x, Mathf.Lerp(camera.localPosition.y, defaultPosY, Time.deltaTime * setting.walkingBobbingSpeed), camera.localPosition.z);
                return;
            }
            else if(playerStateCTRL.postureState == PlayerPostureState.Crouch) {
                timer += Time.deltaTime * setting.crouchBobbingSpeed;
            }
            else if (playerStateCTRL.moveState == PlayerMoveState.Walk) {
                //Player is moving
                timer += Time.deltaTime * setting.walkingBobbingSpeed;
            }
            else if (playerStateCTRL.moveState == PlayerMoveState.Move) {
                //Player is moving
                timer += Time.deltaTime * setting.moveBobbingSpeed;
            }
            else if (playerStateCTRL.moveState == PlayerMoveState.Run) {
                //Player is moving
                timer += Time.deltaTime * setting.runBobbingSpeed;
            }

            camera.localPosition = new Vector3(camera.localPosition.x, defaultPosY + Mathf.Sin(timer) * setting.bobbingAmount, camera.localPosition.z);
        }
        #endregion
    }
}
