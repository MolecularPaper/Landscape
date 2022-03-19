using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

[System.Serializable]
public class PlayerData 
{
    public float x = 0.0f;
    public float y = 0.0f;
    public float z = 0.0f;

    public float angleX = 0.0f;
    public float angleY = 0.0f;

    public PlayerData(GameObject player, PlayerViewCTRL playerViewCTRL)
    {
        x = player.transform.position.x;
        y = player.transform.position.y;
        z = player.transform.position.z;

        angleX = playerViewCTRL.CurrentXAngle;
        angleY = playerViewCTRL.CurrentYAngle;
    }
}
