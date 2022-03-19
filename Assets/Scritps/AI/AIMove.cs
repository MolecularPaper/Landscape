using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] PlayerMoveSettingData setting;

    [Header("Info")]
    [SerializeField, ReadOnly] public AIState state;
    [SerializeField, ReadOnly] private NavMeshAgent nav;
    [SerializeField, ReadOnly] private Animator animator;
    [ReadOnly] public Vector3 movePos;

    void Awake()
    {
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        SetSpeed();
    }

    void Update()
    {
        UpdateAnimator();
    }

    public void MoveTarget(Vector3 targetPos, AIState state)
    {
        movePos = targetPos;

        this.state = state;
        SetSpeed();
        nav.SetDestination(targetPos);
    }

    private void SetSpeed()
    {
        switch (state) {
            case AIState.Stop:
                nav.speed = 0;
                break;
            case AIState.Walk:
                nav.speed = setting.speed;
                break;
            case AIState.Run:
                nav.speed = setting.speed * setting.runMulti / 2;
                break;
        }
    }

    private void UpdateAnimator()
    {
        if (!animator) return;
        animator.SetInteger("Motion", (int)state);
    }
}
