using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MoveSettingData", menuName = "MoveSettingData", order = 2)]
public class PlayerMoveSettingData : ScriptableObject
{

    /// <summary>
    /// �÷��̾� �̵� �ӵ�
    /// </summary>
    [SerializeField] private float _speed;

    /// <summary>
    /// �÷��̾� �޸��� �ӷ� ����
    /// </summary>
    [SerializeField, Range(1.1f, 2.0f)] private float _runMulti;

    /// <summary>
    /// �÷��̾� �ȱ� �ӷ� ����
    /// </summary>
    [SerializeField, Range(0.1f, 1.0f)] private float _walkMulti;


    /// <summary>
    /// �÷��̾ �ɾƼ� �̵��� �ӷ� ����
    /// </summary>
    [SerializeField, Range(0.1f, 1.0f)] private float _crouchMulti; 

    /// <summary>
    /// �÷��̾� ���� �ӷ�
    /// </summary>
    [Space(10)]
    [SerializeField] private float _jumpSpeed;

    /// <summary>
    /// �ִ� ������
    /// </summary>
    [Space(10)]
    [SerializeField] private float _maxFriction;

    /// <summary>
    /// �̵� �ӵ� ����
    /// </summary>
    [SerializeField] private float _moveSpeedLerp;

    /// <summary>
    /// �ִ� �ö� �� �ִ� ����
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
