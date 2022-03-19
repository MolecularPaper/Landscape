using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerViewCTRL : MonoBehaviour
    {
        #region Visible Variables
        [Header("Location")]
        [SerializeField] private Transform playerHeadPivot;

        [Header("Setting")]
        [SerializeField] private PlayerViewSettingData setting;

        #endregion

        #region Properties
        public bool Freeze { get; set; }

        /// <summary>
        /// 시점 x축의 현재 회전 각도
        /// </summary>
        public float CurrentXAngle { get; set; }

        /// <summary>
        /// 시점 y축의 현재 회전 각도
        /// </summary>
        public float CurrentYAngle { get; set; }

        public Transform lookAt;

        private new Rigidbody rigidbody { get; set; }

        /// <summary>
        /// 마우스 델타값
        /// </summary>
        private Vector2 mouseDelta { get; set; }
        #endregion

        #region Unity Event Methods
        private void Awake()
        {
            rigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        }

        private void Start()
        {
            SetInputSystem();
        }

        private void Update()
        {
            LookAt();
            UpdateCameraPostion();
        }
        #endregion

        #region Methods
        /// <summary>
        /// InputSystem의 각 키 이벤트마다 실행할 메소드 등록
        /// </summary>
        private void SetInputSystem()
        {
            //시점 조작 키 이벤트(델타값으로 받아옴)
            PlayerInput.input.fpc.Player.ViewControll.performed += val => mouseDelta = val.ReadValue<Vector2>();
            PlayerInput.input.fpc.Player.ViewControll.canceled += val => mouseDelta = val.ReadValue<Vector2>();
        }

        /// <summary>
        /// 카메라 위치 업데이트
        /// </summary>
        private void UpdateCameraPostion()
        {
            if (!Freeze) {
                int xAxisInversion = setting.xAxisInversion ? -1 : 1;
                int yAxisInversion = setting.yAxisInversion ? -1 : 1;

                CurrentXAngle += Time.deltaTime * -mouseDelta.y * setting.xAxisSensitivity * xAxisInversion;
                CurrentXAngle = Mathf.Clamp(CurrentXAngle, setting.minAngleX, setting.maxAngleX);

                CurrentYAngle += Time.deltaTime * mouseDelta.x * setting.yAxisSensitivity * yAxisInversion;

                rigidbody.rotation = Quaternion.Euler(0, CurrentYAngle, 0);
                rigidbody.angularVelocity = Vector3.zero;
                playerHeadPivot.localRotation = Quaternion.Euler(CurrentXAngle, 0, 0);
            }
        }

        public void SetSetting(GeneralSettingData data)
        {
            //General - MouseSensitivity
            setting.xAxisSensitivity = data.mouseSensitivity;
            setting.yAxisSensitivity = data.mouseSensitivity;

            //General - XAxisInversion
            setting.xAxisInversion = data.xAxisInversion;

            //General - YAxisInversion
            setting.yAxisInversion = data.yAxisInversion;
        }

        public void SetLookTarget(Transform target) => lookAt = target;

        private void LookAt()
        {
            if (!lookAt) return;

            Vector3 lookDir = lookAt.position - playerHeadPivot.position;
            Quaternion lookRot = Quaternion.LookRotation(lookDir);

            if (Quaternion.Angle(playerHeadPivot.rotation, lookRot) >= 0.2f) {
                playerHeadPivot.rotation = Quaternion.Lerp(playerHeadPivot.rotation, lookRot, 30f * Time.deltaTime);
            }
            else {
                CurrentXAngle = lookRot.eulerAngles.x;
                CurrentYAngle = lookRot.eulerAngles.y;
                lookAt = null;
            }
        }
        #endregion

        #region Debug
        //디버그 메소드 작성(있을경우)
        #endregion

    }
}