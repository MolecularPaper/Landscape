using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MoveSettingData", menuName = "MoveSettingData", order = 2)]
public class PlayerMoveSettingData : ScriptableObject
{

    /// <summary>
    /// 플레이어 이동 속도
    /// </summary>
    [SerializeField] private float _speed;

    /// <summary>
    /// 플레이어 달리기 속력 배율
    /// </summary>
    [SerializeField, Range(1.1f, 2.0f)] private float _runMulti;

    /// <summary>
    /// 플레이어 걷기 속력 배율
    /// </summary>
    [SerializeField, Range(0.1f, 1.0f)] private float _walkMulti;


    /// <summary>
    /// 플레이어가 앉아서 이동시 속력 배율
    /// </summary>
    [SerializeField, Range(0.1f, 1.0f)] private float _crouchMulti; 

    /// <summary>
    /// 플레이어 점프 속력
    /// </summary>
    [Space(10)]
    [SerializeField] private float _jumpSpeed;

    /// <summary>
    /// 최대 마찰력
    /// </summary>
    [Space(10)]
    [SerializeField] private float _maxFriction;

    /// <summary>
    /// 이동 속도 보간
    /// </summary>
    [SerializeField] private float _moveSpeedLerp;

    /// <summary>
    /// 최대 올라갈 수 있는 각도
    /// </summary>
    [Space(10)]
    [SerializeField] private float _maxSlopeAngle;


    public float speed => _speed;
    public float runMulti => _runMulti;
    public float walkMulti => _walkMulti;
    public float crouchMulti => _crouchMulti;
    public float jumpSpeed => _jumpSpeed;
    public float maxFriction => _maxFriction;
    public float moveSpeedLerp => _moveSpeedLerp;
    public float maxSlopeAngle => _maxSlopeAngle;
}
