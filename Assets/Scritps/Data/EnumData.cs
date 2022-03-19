using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public enum PotalTriggerType
    {
        Interaction,
        Enter,
    }

    [System.Serializable]
    public enum PotalType
    {
        StageChange,
        Teleport
    }

    [System.Serializable]
    public enum ItemType
    {
        Consumable,
        Key,
        Etc
    }

    public enum PlayerMoveState
    {
        Stop,
        Walk,
        Move,
        Run,
    }

    public enum PlayerPostureState
    {
        Standing,
        Crouch,
    }
}
