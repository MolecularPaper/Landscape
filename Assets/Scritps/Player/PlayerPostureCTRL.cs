using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

namespace Player
{
    //플레이어 포즈 제어 스크립트
    public class PlayerPostureCTRL : MonoBehaviour
    {
        #region  Visble Variables
        [Header("Location")]
        [SerializeField] private Transform playerHeadPivot;
        #endregion

        #region Properties
        //Components
        private new CapsuleCollider collider { get; set; }
        private PlayerStateCTRL playerStateCTRL { get; set; }

        private float standingHeight { get; set; }
        private float crouchHeight { get; set; }
        private float raiseHeight { get; set; }
        #endregion

        #region Unity Event Methods
        //이벤트 메소드 작성
        private void Awake()
        {
            collider = GameObject.FindWithTag("Player").GetComponent<CapsuleCollider>();
            playerStateCTRL = GetComponent<PlayerStateCTRL>();

            standingHeight = collider.height;
            crouchHeight = collider.height / 2;
            raiseHeight = collider.radius;
        }
        
        private void Update()
        {
            if(playerStateCTRL.postureState == PlayerPostureState.Standing) {
                collider.height = Mathf.Lerp(collider.height, standingHeight, Time.deltaTime * 5.0f);
            }
            else if (playerStateCTRL.postureState == PlayerPostureState.Crouch) {
                collider.height = Mathf.Lerp(collider.height, crouchHeight, Time.deltaTime * 5.0f);
            }

            collider.center = new Vector3(0, collider.height / 2, 0);
            playerHeadPivot.localPosition = new Vector3(0, collider.height - 0.1f);
        }
        #endregion
        
        #region Methods
        //일반 메소드 작성
        #endregion
        
        #region Debug
        //디버그 메소드 작성(있을경우)
        #endregion
        
    }
}
