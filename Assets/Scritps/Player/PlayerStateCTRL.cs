using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

namespace Player
{
    //플레이어 상태 제어
    public class PlayerStateCTRL : MonoBehaviour
    {
        #region Properties
        public PlayerMoveState moveState { get; set; }
        public PlayerPostureState postureState { get; set; }

        private PlayerPhysic playerPhysic { get; set; }
        private Rigidbody rb { get; set; }

        private bool move { get; set; }
        private bool run { get; set; }
        private bool walk { get; set; }
        private bool crouch { get; set; }
        #endregion

        #region Unity Event Methods
        private void Awake()
        {
            playerPhysic = GetComponent<PlayerPhysic>();
            rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();

            moveState = PlayerMoveState.Stop;
            postureState = PlayerPostureState.Standing;
        }

        //이벤트 메소드 작성
        private void Start()
        {
            SetInputSystem();
        }

        private void Update()
        {
            if (!playerPhysic.IsGround) {
                postureState = PlayerPostureState.Standing;
            }

            ChangeState();
        }

        #endregion

        #region Methods
        /// <summary>
        /// InputSystem의 각 키 이벤트마다 실행할 메소드 등록
        /// </summary>
        private void SetInputSystem()
        {
            //전후좌우 이동 키 이벤트
            PlayerInput.input.fpc.Player.Movement.performed += val => {
                move = true;
            };
            PlayerInput.input.fpc.Player.Movement.canceled += val => {
                move = false;
 
            };

            //달리기 키 이벤트(홀드)
            PlayerInput.input.fpc.Player.Run.performed += val => {
                run = true;
            };
            PlayerInput.input.fpc.Player.Run.canceled += val => {
                run = false;
            };

            //걷기 키 이벤트(홀드)
            PlayerInput.input.fpc.Player.Walk.performed += val => {
                walk = true;
            };
            PlayerInput.input.fpc.Player.Walk.canceled += val => {
                walk = false;
            };

            //앉기 키 이벤트(토글)
            PlayerInput.input.fpc.Player.Crouch.performed += val => {
                if(crouch) crouch = !playerPhysic.CanCrouchUp;
                else crouch = true;
            };
        }

        private void ChangeState()
        {
            move = rb.velocity.magnitude > 0.3f;

            if (!crouch && !walk && move && run) {
                moveState = PlayerMoveState.Run;
            }
            else if (!crouch && !run && move && walk) {
                moveState = PlayerMoveState.Walk;
            }
            else if (move) {
                moveState = PlayerMoveState.Move;
            }
            else {
                moveState = PlayerMoveState.Stop;
            }

            if (crouch) {
                postureState = PlayerPostureState.Crouch;
            }
            else{
                postureState = PlayerPostureState.Standing;
            }
        }
        #endregion

        #region Debug
        //디버그 메소드 작성(있을경우)
        #endregion

    }
}
