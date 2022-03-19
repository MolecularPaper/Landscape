using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Manager
{
    public class CursorManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private bool lockCursorOnStart;
        #endregion

        #region Properties
        private static PlayerViewCTRL playerViewCTRL { get; set; }
        private static PlayerMoveCTRL playerMoveCTRL { get; set; }
        #endregion

        #region Unity Event Methods
        //이벤트 메소드 작성
        void Awake()
        {
            playerViewCTRL = FindObjectOfType<PlayerViewCTRL>();
            playerMoveCTRL = FindObjectOfType<PlayerMoveCTRL>();

            CusorLock(lockCursorOnStart);
        }
        #endregion

        #region Methods
        public static void CusorLock(bool cusorLocked)
        {
            Cursor.lockState = cusorLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !cusorLocked;

            if(playerViewCTRL != null) playerViewCTRL.Freeze = !cusorLocked;
            if (playerMoveCTRL != null) playerMoveCTRL.Freeze = !cusorLocked;
        }
        #endregion

        #region Debug
        //디버그 메소드 작성(있을경우)
        #endregion
    }
}
