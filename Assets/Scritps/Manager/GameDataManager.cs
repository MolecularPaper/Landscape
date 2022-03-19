using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Player;
using Data;

namespace Manager
{
    //스크립트 개요 작성
    public class GameDataManager : MonoBehaviour
    {
        #region Variables

        private PlayerInventroyCTRL playerInventroy { get; set; }
        public static GameDataManager gdm;
        public UnityAction saveData;

        [Header("Save Setting")]
        [SerializeField] private bool enabledStageSave;
        [SerializeField] private bool enabledInventorySave;
        [SerializeField] private bool enabledPlayerSave;
        [SerializeField] private bool enabledItemSave;
        [SerializeField] private bool enabledDoorSave;
        [SerializeField] private bool enabledEventSave;
        private bool haveSaveData
        {
            get
            {
                return enabledStageSave || enabledInventorySave || enabledPlayerSave || enabledItemSave || enabledItemSave || enabledDoorSave || enabledEventSave;
            }
        }

        [Header("Load Setting")]
        [SerializeField] private bool enabledPlayerLoad;
        [SerializeField] private bool enabledItemLoad;
        [SerializeField] private bool enabledDoorLoad;
        [SerializeField] private bool enabledEventLoad;


        [Header("Info")]
        [SerializeField, ReadOnly] private List<Item> items;
        [SerializeField, ReadOnly] private List<Door> doors;
        [SerializeField, ReadOnly] private List<Collider> eventZones;

        [ReadOnly] public string startSceneName = "Intro";
        #endregion

        #region Properties
        private string SceneName => SceneManager.GetActiveScene().name;
        private string GlobalSavePath => Application.persistentDataPath + $"/Landscape GameData/";
        private string SavePath => GlobalSavePath + SceneName + "/";
      
        #endregion

        #region Unity Event Methods
        private void Awake()
        {
            gdm = this;

            playerInventroy = FindObjectOfType<PlayerInventroyCTRL>();
            
            LoadData();
            SetSaveAction();
            CheckSettingDataDiretory();
        }
        #endregion

        #region Methods
        [ContextMenu("Get save object")]
        private void GetSaveObject()
        {
            Item[] items = FindObjectsOfType<Item>();
            Door[] doors = FindObjectsOfType<Door>();
            EventZone[] eventZones = FindObjectsOfType<EventZone>();

            foreach (var item in items) {
                if (!this.items.Contains(item)) this.items.Add(item);
            }

            foreach (var item in doors) {
                if (!this.doors.Contains(item)) this.doors.Add(item);
            }

            foreach (var item in eventZones) {
                Collider coll = item.GetComponent<Collider>();
                if (!this.eventZones.Contains(coll)) this.eventZones.Add(coll);
            }
        }

        private void LoadData()
        {
            if(enabledEventLoad) LoadEventZoneData();
            if (enabledPlayerLoad) LoadPlayerData();
            if (enabledDoorLoad) LoadDoorData();
            if (enabledItemLoad) LoadItemData();
        }

        private void SetSaveAction()
        {
            saveData += CheckGameDataDirectory;

            if (!haveSaveData) return;
            if(enabledStageSave) saveData += SaveStageData;
            if(enabledInventorySave) saveData += SaveInventoryData;
            if (enabledEventSave) saveData += SaveEventZoneData;
            if (enabledPlayerSave) saveData += SavePlayerData;
            if (enabledDoorSave) saveData += SaveDoorData;
            if (enabledItemSave) saveData += SaveItemData;
        }

        private void CheckGameDataDirectory()
        {
            if (haveSaveData && !Directory.Exists(SavePath)) {
                Directory.CreateDirectory(SavePath);
            }
        }

        private void CheckSettingDataDiretory()
        {
            if (!Directory.Exists(GlobalSavePath + "Setting")) {
                Directory.CreateDirectory(GlobalSavePath + "Setting");
            }
        }

        #region Stage Data
        public void SaveStageData()
        {
            if (doors.Count == 0) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(GlobalSavePath + "Stage.sav", FileMode.Create);

            bf.Serialize(stream, SceneManager.GetActiveScene().name);
            stream.Close();
        }

        public void LoadStageData()
        {
            if (!File.Exists(GlobalSavePath + "Stage.sav")) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(GlobalSavePath + "Save.sav", FileMode.Open);

            startSceneName = bf.Deserialize(stream) as string;
            stream.Close();

        }
        #endregion

        #region Player Data
        private void SavePlayerData()
        {
            GameObject player = GameObject.Find("Player");
            PlayerViewCTRL playerViewCTRL = player.GetComponentInChildren<PlayerViewCTRL>();

            if (!playerViewCTRL) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(SavePath + "Player.sav", FileMode.Create);

            PlayerData playerData = new PlayerData(player, playerViewCTRL);

            bf.Serialize(stream, playerData);
            stream.Close();
        }

        private void LoadPlayerData()
        {
            GameObject player = GameObject.Find("Player");
            PlayerViewCTRL playerViewCTRL = player.GetComponentInChildren<PlayerViewCTRL>();

            if (!File.Exists(SavePath + "Player.sav")) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(SavePath + "Player.sav", FileMode.Open);

            PlayerData playerData = bf.Deserialize(stream) as PlayerData;
            stream.Close();

            print(new Vector3(playerData.x, playerData.y, playerData.z));
            player.transform.position = new Vector3(playerData.x, playerData.y, playerData.z);
            playerViewCTRL.CurrentXAngle = playerData.angleX;
            playerViewCTRL.CurrentYAngle = playerData.angleY;
        }
        #endregion

        #region Door Data

        public void SaveDoorData()
        {
            if (doors.Count == 0) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(SavePath + "Door.sav", FileMode.Create);

            List<DoorData> doorDatas = new List<DoorData>();
            foreach (var door in doors) doorDatas.Add(door.doorData);

            bf.Serialize(stream, doorDatas.ToArray());
            stream.Close();
        }

        public void LoadDoorData()
        {
            if (!File.Exists(SavePath + "Door.sav")) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(SavePath + "Door.sav", FileMode.Open);

            DoorData[] doorDatas = bf.Deserialize(stream) as DoorData[];
            stream.Close();

            for (int i = 0; i < doors.Count; i++) {
                doors[i].SetData(doorDatas[i]);
            }
        }
        #endregion

        #region EventZone Data

        public void SaveEventZoneData()
        {
            if (eventZones.Count == 0) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(SavePath + "EventZone.sav", FileMode.Create);

            List<bool> datas = new List<bool>();
            foreach (var eventZone in eventZones) datas.Add(eventZone.enabled);

            bf.Serialize(stream, datas.ToArray());
            stream.Close();
        }

        public void LoadEventZoneData()
        {
            if (!File.Exists(SavePath + "EventZone.sav")) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(SavePath + "EventZone.sav", FileMode.Open);

            bool[] datas = bf.Deserialize(stream) as bool[];
            stream.Close();

            for (int i = 0; i < eventZones.Count; i++) {
                eventZones[i].enabled = datas[i];
                print(eventZones[i].enabled + ", " + datas[i]);
            }
        }
        #endregion

        #region Item Object Data
        public void SaveItemData()
        {
            if (items.Count == 0) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(SavePath + "Item.sav", FileMode.Create);

            List<bool> itemDatas = new List<bool>();
            foreach (var item in items) itemDatas.Add((item.gameObject.activeSelf));

            bf.Serialize(stream, itemDatas.ToArray());
            stream.Close();
        }

        public void LoadItemData()
        {
            if (!File.Exists(SavePath + "Item.sav")) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(SavePath + "Item.sav", FileMode.Open);

            bool[] itemDatas = bf.Deserialize(stream) as bool[];
            stream.Close();

            for (int i = 0; i < items.Count; i++) {
                items[i].gameObject.SetActive(itemDatas[i]);
            }
        }
        #endregion

        #region Inventory Data
        public void SaveInventoryData()
        {
            if (playerInventroy == null) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(GlobalSavePath + "Inventory.sav", FileMode.Create);

            bf.Serialize(stream, playerInventroy.haveItems.ToArray());
            stream.Close();
        }

        public string[] LoadInventoryData()
        {
            if (!File.Exists(GlobalSavePath + "Inventory.sav")) return new string[0];

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(GlobalSavePath + "Inventory.sav", FileMode.Open);

            string[] itemCodes = bf.Deserialize(stream) as string[];

            stream.Close();

            return itemCodes;
        }
        #endregion

        #region Setting Data
        public void SaveSettingData(SettingManager settingManager)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream_general = new FileStream(GlobalSavePath + "Setting/General.sav", FileMode.Create);
            FileStream stream_graphic = new FileStream(GlobalSavePath + "Setting/Graphic.sav", FileMode.Create);
            FileStream stream_display = new FileStream(GlobalSavePath + "Setting/Display.sav", FileMode.Create);
            FileStream stream_sound = new FileStream(GlobalSavePath + "Setting/Sound.sav", FileMode.Create);

            bf.Serialize(stream_general, settingManager.generalSettingData);
            bf.Serialize(stream_graphic, settingManager.graphicSettingData);
            bf.Serialize(stream_display, settingManager.displaySettingData);
            bf.Serialize(stream_sound, settingManager.soundSettingData);

            stream_general.Close();
            stream_graphic.Close();
            stream_display.Close();
            stream_sound.Close();
        }

        public void LoadSettingData(SettingManager settingManager)
        {
            if (!File.Exists(GlobalSavePath + "Setting/General.sav") ||
                !File.Exists(GlobalSavePath + "Setting/Display.sav") ||
                !File.Exists(GlobalSavePath + "Setting/Graphic.sav") ||
                !File.Exists(GlobalSavePath + "Setting/Sound.sav")) return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream_general = new FileStream(GlobalSavePath + "Setting/General.sav", FileMode.Open);
            FileStream stream_graphic = new FileStream(GlobalSavePath + "Setting/Graphic.sav", FileMode.Open);
            FileStream stream_display = new FileStream(GlobalSavePath + "Setting/Display.sav", FileMode.Open);
            FileStream stream_sound = new FileStream(GlobalSavePath + "Setting/Sound.sav", FileMode.Open);

            settingManager.generalSettingData = new GeneralSettingData(bf.Deserialize(stream_general) as GeneralSettingData);
            settingManager.graphicSettingData = new GraphicSettingData(bf.Deserialize(stream_graphic) as GraphicSettingData);
            settingManager.displaySettingData = new DisplaySettingData(bf.Deserialize(stream_display) as DisplaySettingData);
            settingManager.soundSettingData = new SoundSettingData(bf.Deserialize(stream_sound) as SoundSettingData);

            stream_general.Close();
            stream_graphic.Close();
            stream_display.Close();
            stream_sound.Close();
        }
        #endregion

        #endregion
    }
}