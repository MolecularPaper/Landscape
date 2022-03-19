using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAI : MonoBehaviour
{
    [SerializeField] private GameObject ai;
    [SerializeField] private Transform[] spawnPoints;

    void Awake()
    {
        int index = Random.Range(0, spawnPoints.Length - 1);

        Instantiate(ai, spawnPoints[index].position, Quaternion.identity);
    }
}
