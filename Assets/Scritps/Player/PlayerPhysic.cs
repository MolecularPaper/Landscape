using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerPhysic : MonoBehaviour
    {
        #region Variables
        //Components
        private new CapsuleCollider collider;
        private Transform playerTransfrom;

        private bool isGround = false;
        public UnityAction landEvent;
        #endregion

        #region Properties
        /// <summary>
        /// ���鿡 ��� �ִ��� ����
        /// </summary>
        public bool IsGround
        {
            get => isGround;
            set
            {
                if (value == isGround) return;
                isGround = value;
                if (isGround) landEvent.Invoke();
            }
        }

        /// <summary>
        /// ������� �ִ��� ����
        /// </summary>
        public bool IsStair
        {
            get
            {
                RaycastHit hit;
                Physics.SphereCast(GroundSphereOffset, SafeRadius, Vector3.down, out hit, 0.1f);
                return hit.transform != null && hit.transform.gameObject.tag == "Stair";
            }
        }

        public bool CanCrouchUp
        {
            get
            {
                RaycastHit hit;
                int layerMask = (1 << LayerMask.NameToLayer("Player"));
                Physics.SphereCast(playerTransfrom.position, SafeRadius, Vector3.up, out hit, collider.height);
                return hit.transform == null;
            }
        }

        /// <summary>
        /// �ٴ��� ǥ�� ����
        /// </summary>
        public float SurfaceAngle
        {
            get
            {
                var angle = 0f;
                RaycastHit hit;
                if (Physics.SphereCast(GroundSphereOffset, collider.radius, Vector3.down, out hit, 0.1f)) {
                    angle = Vector3.Angle(Vector3.up, hit.normal) + 0.05f;
                }
                return Mathf.Round(angle);
            }
        }

        /// <summary>
        /// ĸ�� �ݶ��̴� �ϴ��� �߽���ǥ
        /// </summary>
        public Vector3 GroundSphereCenter => new Vector3(playerTransfrom.position.x, playerTransfrom.position.y + collider.radius, playerTransfrom.position.z);

        /// <summary>
        /// ĸ�� �ݶ��̴� �ϴ��� �߽���ǥ + ������
        /// </summary>
        public Vector3 GroundSphereOffset => GroundSphereCenter + (Vector3.up * (collider.radius * 0.1f));

        public float SafeRadius => collider.radius * 0.95f;
        #endregion

        #region Unity Event Methods
        private void Awake()
        {
            collider = GameObject.FindWithTag("Player").GetComponent<CapsuleCollider>();
            playerTransfrom = GameObject.FindWithTag("Player").transform;
        }

        private void Update()
        {
            IsGround = Physics.SphereCast(new Ray(GroundSphereOffset, Vector3.down), SafeRadius, 0.1f);
        }
        #endregion
    }
}