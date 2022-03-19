using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using Data;

namespace Player
{
    //플레이어 상호작용 컨트롤러
    public class PlayerInteraction : MonoBehaviour
    {
        #region Variables
        private PlayerInventroyCTRL inventroyCTRL;

        [SerializeField] 
        private AudioClip itemGetSound;
        private AudioSource audioSource;

        /// <summary>
        /// 문 상호작용시 문이 잠겨있을경우 표시될 텍스트
        /// </summary>
        [SerializeField] private string ifDoorIsLocked;
        #endregion
        
        #region Properties
        private RaycastHit hit
        {
            get
            {
                RaycastHit hit;
                int layerMask = (1 << LayerMask.NameToLayer("Player"));
                layerMask = ~layerMask;
                Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1.5f, layerMask);
                return hit;
            }
        }
        #endregion

        #region Unity Event Methods
        private void Awake()
        {
            inventroyCTRL = GetComponent<PlayerInventroyCTRL>();

            audioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
        }

        private void Start()
        {
            SetInputSystem();
        }
        #endregion

        #region Methods
        private void SetInputSystem()
        {
            PlayerInput.input.fpc.Player.Interaction.performed += val => {
                InteractionObject();
            };
        }

        private void InteractionObject()
        {
            if (hit.transform == null) return;

            switch (hit.transform.tag) {
                case "Potal":
                    PotalInteraction(hit.transform);
                    break;
                case "Door":
                    DoorInteraction(hit.transform);
                    break;
                case "Item":
                    ItemInteraction(hit.transform);
                    break;
                case "Button":
                    ButtonInterection(hit.transform);
                    break;
                default:
                    break;
            }
        }

        private void PotalInteraction(Transform hit)
        {
            Potal potal = hit.GetComponentInParent<Potal>();
            potal.Interaction();
        }

        private void DoorInteraction(Transform hit)
        {
            Door door = hit.GetComponentInParent<Door>();

            if (!door.doorData.canOpen) return;

            if (!door.doorData.doorLocked) {
                door.Interection();
                return;
            }

            if (inventroyCTRL.FindKey(door.doorKeyItemCode)) {
                if (ItemDataManager.idm.GetItem(door.doorKeyItemCode).disposable) {
                    inventroyCTRL.RemoveItem(door.doorKeyItemCode);
                }
                door.DoorUnLock();
            }
            else {
                InfoUI.infoUI.ShowInfo(ifDoorIsLocked);
            }
        }

        private void ItemInteraction(Transform hit)
        {
            Item item = hit.GetComponent<Item>();
            item.gameObject.SetActive(false);

            inventroyCTRL.GetItem(item.itemCode);
            audioSource.PlayOneShot(itemGetSound);
        }

        private void ButtonInterection(Transform hit) => hit.GetComponent<Button>().PressButron();
        #endregion
    }
}
