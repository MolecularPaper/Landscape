using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIMove))]
public class AIFindPoint : MonoBehaviour
{
    [SerializeField] private AIState defaultState = AIState.Stop;

    [Header("Info")]
    [SerializeField, ReadOnly] private GameObject[] movePoints;
    [SerializeField, ReadOnly] private AIFindPlayer aIFindPlayer;
    [SerializeField, ReadOnly] private AIMove aIMove;

    void Awake()
    {
        aIMove = GetComponent<AIMove>();
        aIFindPlayer = GetComponent<AIFindPlayer>();
        movePoints = GameObject.FindGameObjectsWithTag("AIMovePoint");

        SearchPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (aIFindPlayer && !aIFindPlayer.isFind && Vector3.Distance(transform.position, aIMove.movePos) < 0.1f) {
            SearchPoint();
        }
    }
    private void SearchPoint()
    {
        print("SearchPoint");
        aIMove.MoveTarget(movePoints[Random.Range(0, movePoints.Length - 1)].transform.position, defaultState);
    }
}
