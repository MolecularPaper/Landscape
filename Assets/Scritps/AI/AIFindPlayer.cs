using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

[RequireComponent(typeof(AIMove))]
public class AIFindPlayer : MonoBehaviour
{
    [SerializeField] private Transform head;

    [Space(10)]
    [SerializeField] private float viewAngle;
    [SerializeField] private float viewRadius;
    [SerializeField] private LayerMask viewTargetMask;
    [SerializeField] private LayerMask viewObstacleMask;
    [SerializeField] private AIState defaultState;

    [Space(10)]
    [SerializeField] private float walkSearchDistance;
    [SerializeField] private float moveSearchDistance;
    [SerializeField] private float runSearchDistance;

    [Header("Info")]
    [SerializeField, ReadOnly] private AIMove aIMove;
    [ReadOnly] public bool isFind;

    void Awake()
    {
        aIMove = GetComponent<AIMove>();
    }

    void Update()
    {
        FindTargets();
    }
    void FindTargets()
    {
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, viewTargetMask);

        for (int i = 0; i < targetInViewRadius.Length; i++) {
            Transform target = targetInViewRadius[i].transform; //타겟[i]의 위치 
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            float dstToTarget = Vector3.Distance(transform.position, target.position); //타겟과의 거리를 계산 
            SearchSound(target, dstToTarget);
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) {
                if (!Physics.Raycast(head.position, dirToTarget, dstToTarget, viewObstacleMask)) {
                    SetTarget(target);
                    return;
                }
            }
        }

        if (isFind && Vector3.Distance(transform.position, aIMove.movePos) <= 0.1f) isFind = false;
    }

    private void SearchSound(Transform target, float dstToTarget)
    {
        PlayerStateCTRL ctrl = target.GetComponentInChildren<PlayerStateCTRL>();
        if (ctrl.moveState == Data.PlayerMoveState.Walk && dstToTarget <= walkSearchDistance) {
            SetTarget(target);
        }
        else if (ctrl.moveState == Data.PlayerMoveState.Move && dstToTarget <= moveSearchDistance) {
            SetTarget(target);
        }
        else if (ctrl.moveState == Data.PlayerMoveState.Run && dstToTarget <= runSearchDistance) {
            SetTarget(target);
        }
    }

    private void SetTarget(Transform target)
    {
        print($"플레이어 발견, 좌표 : {target.position}");
        isFind = true;
        aIMove.MoveTarget(target.position, defaultState);
    }
}
