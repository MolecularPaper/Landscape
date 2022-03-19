using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using TMPro;
using System;

namespace UICTRL
{
    //상호작용 UI 컨트롤러
    public class InterectionUICTRL : MonoBehaviour
    {
        #region Variables
        private PlayerInventroyCTRL inventroyCTRL;

        [SerializeField] private GameObject aimingDot;
        [SerializeField] private GameObject InterectionPanel;
        [SerializeField] private TextMeshProUGUI InteractionText;

        [Header("Interection Text")]
        [SerializeField] private string potal;
        [SerializeField] private string unlockDoor;
        [SerializeField] private string doorLocked;
        [SerializeField] private string doorClose;
        [SerializeField] private string doorOpen;
        [SerializeField] private string getItem;
        [SerializeField] private string pressButton;
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
        //이벤트 메소드 작성
        private void Awake()
        {
            inventroyCTRL = FindObjectOfType<PlayerInventroyCTRL>();

            aimingDot.SetActive(false);
        }
        void Update()
        {
            if(GameObject.FindWithTag("Player")) SetInterectionText();
        }
        #endregion

        #region Methods
        private void SetInterectionText()
        {
            if (hit.transform == null){
                OnOff(false);
                return;
            }

            switch (hit.transform.tag) {
                case "Potal":
                    PotalUI();
                    break;
                case "Door":
                    DoorUI();
                    break;
                case "Item":
                    ItemUI();
                    break;
                case "Button":
                    ButtonUI();
                    break;
                default:
                    OnOff(false);
                    return;
            }

            OnOff(true);
        }

        private void PotalUI()
        {
            print(hit.transform);
            if (!hit.transform.GetComponent<Potal>().potalLocked) InteractionText.text = potal;
        }

        private void ItemUI()
        {
            InteractionText.text = getItem;
        }

        private void ButtonUI()
        {
             if(hit.transform.GetComponent<Button>().canPress) InteractionText.text = pressButton;
        }

        private void DoorUI()
        {
            Door door = hit.transform.GetComponentInParent<Door>();

            if (!door.doorData.canOpen) return;
            if (door.doorData.doorLocked && inventroyCTRL.FindKey(door.doorKeyItemCode)) InteractionText.text = unlockDoor;
            else if (door.doorData.doorLocked && !inventroyCTRL.FindKey(door.doorKeyItemCode)) InteractionText.text = doorLocked;
            else if (door.doorData.doorOpen) InteractionText.text = doorClose;
            else InteractionText.text = doorOpen;
        }

        private void OnOff(bool active)
        {
            aimingDot.SetActive(active);
            InterectionPanel.SetActive(active);
        }
        #endregion
    }
}
