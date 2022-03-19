using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

namespace Player
{
    //플레이어의 이동 제어 스크립트(앞뒤좌우, 점프)
    public class PlayerMoveCTRL : MonoBehaviour
    {
        #region Visible Variables
        /// <summary>
        /// 이동 변수 데이터
        /// </summary>
        [Header("Setting")]
        [SerializeField] private PlayerMoveSettingData setting;
        #endregion

        #region Properties
        //Components
        private PlayerStateCTRL playerStateCTRL { get; set; }
        private PlayerPhysic playerPhysic { get; set; }

        private Transform playerTransfrom { get; set; }
        private new Rigidbody rigidbody { get; set; }
        private new CapsuleCollider collider { get; set; }

        /// <summary>
        /// 현재 속력
        /// </summary>
        private float currentSpeed { get; set; }

        /// <summary>
        /// 이동 방향
        /// </summary>
        private Vector3 moveDir { get; set; }

        private Vector3 lerpDir;

        private Vector3 LerpDir
        {
            get
            {
                lerpDir = Vector3.Lerp(lerpDir, moveDir, Time.deltaTime * setting.moveSpeedLerp);
                return lerpDir;
            }
        }

        public bool Freeze { get; set; }
        #endregion

        #region Unity Event Methods
        private void Awake()
        {
            playerStateCTRL = GetComponent<PlayerStateCTRL>();
            playerPhysic = GetComponent<PlayerPhysic>();

            playerTransfrom = GameObject.FindWithTag("Player").transform;
            rigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
            collider = GameObject.FindWithTag("Player").GetComponent<CapsuleCollider>();
        }

        private void Start()
        {
            SetInputSystem();
        }
        private void FixedUpdate()
        {
            UpdateSpeed();
            UpdateVelocity();
            UpdateFriction();
            StickToGround();
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
                Vector2 input = val.ReadValue<Vector2>();
                moveDir = new Vector3(input.x, 0, input.y); 
            };
            PlayerInput.input.fpc.Player.Movement.canceled += val => {
                moveDir = Vector3.zero;
            };

            //점프 키 이벤트
            PlayerInput.input.fpc.Player.Jump.performed += val => {
                Jump();
            };
        }

        /// <summary>
        /// PlayerMoveState에 따라서 속력 조절
        /// </summary>
        private void UpdateSpeed()
        {
            if (playerPhysic.SurfaceAngle > setting.maxSlopeAngle) 
                currentSpeed = 0.05f;
            else if (playerStateCTRL.moveState == PlayerMoveState.Walk)
                currentSpeed = setting.speed * setting.walkMulti;
            else if (playerStateCTRL.moveState == PlayerMoveState.Run) 
                currentSpeed = setting.speed * setting.runMulti;
            else if (playerStateCTRL.postureState == PlayerPostureState.Crouch)
                currentSpeed = setting.speed * setting.crouchMulti;
            else 
                currentSpeed = setting.speed;
        }

        /// <summary>
        /// Ridibody 속력 업데이트
        /// </summary>
        private void UpdateVelocity()
        {
            Vector3 transfromDir = playerTransfrom.TransformDirection(LerpDir) * currentSpeed;
            if (Freeze) transfromDir = Vector3.zero;

            transfromDir.y = rigidbody.velocity.y;
            rigidbody.velocity = transfromDir;
        }

        private void UpdateFriction()
        {
            if(moveDir == Vector3.zero && (playerPhysic.SurfaceAngle <= setting.maxSlopeAngle || playerPhysic.IsStair)) {
                MaxFriction();
            }
            else {
                MinFriction();
            }
        }
        
        private void MaxFriction()
        {
            collider.material.frictionCombine = PhysicMaterialCombine.Maximum;
            collider.material.staticFriction = setting.maxFriction;
        }

        private void MinFriction()
        {
            collider.material.frictionCombine = PhysicMaterialCombine.Minimum;
            collider.material.staticFriction = 0;
        }

        /// <summary>
        /// 경사면 이동시 바닥으로 부터 떨어지지 않게 rigidbody의 속력을 조절해줌
        /// </summary>
        private void StickToGround()
        {
            if (Physics.SphereCast(playerPhysic.GroundSphereCenter, playerPhysic.SafeRadius, Vector3.down, out RaycastHit hit, 0.075f) && playerPhysic.SurfaceAngle <= setting.maxSlopeAngle || playerPhysic.IsStair) {
                rigidbody.velocity -= Vector3.Project(rigidbody.velocity, hit.normal);
            }
        }

        public void Jump()
        {
            if (playerPhysic.IsGround && playerPhysic.SurfaceAngle <= setting.maxSlopeAngle && playerStateCTRL.postureState == PlayerPostureState.Standing) {
                Vector3 setVelocity = rigidbody.velocity;
                setVelocity.y = 0;
                rigidbody.velocity = setVelocity;
                rigidbody.AddForce(Vector3.up * setting.jumpSpeed, ForceMode.VelocityChange);
            }
        }
        #endregion

        #region Debug
        //디버그 메소드 작성(있을경우)
        #endregion

    }
}
