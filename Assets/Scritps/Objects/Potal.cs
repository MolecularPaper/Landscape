using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Data;
using Manager;
using Player;

public class Potal : MonoBehaviour
{
    public PotalTriggerType potalTriggerType = PotalTriggerType.Interaction;
    public PotalType potalType = PotalType.StageChange;
    public bool potalLocked = false;

    // Potal Type == Teleport ¿œ∂ß «•Ω√µ 
    public Vector3 teleportPostion;
    public Vector2 teleportViewRotation;

    // Potal Type == ChangeStage ¿œ∂ß «•Ω√µ 
    public string changeStageName;

    private void OnCollisionEnter(Collision collision) 
    {
        if (potalTriggerType != PotalTriggerType.Interaction && collision.gameObject.tag == "Player")
            StartPotal();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(potalTriggerType != PotalTriggerType.Interaction && other.gameObject.tag == "Player")
            StartPotal();
    }

    private void StartPotal()
    {
        if (!potalLocked) {
            if (potalType == PotalType.StageChange) {
                GameManager.gm.ChangeStage(changeStageName);
            }
            else {
                GameObject.Find("Player").transform.position = teleportPostion;
                PlayerViewCTRL playerView = GameObject.FindWithTag("Controller").GetComponent<PlayerViewCTRL>();
                playerView.CurrentXAngle = teleportViewRotation.x;
                playerView.CurrentYAngle = teleportViewRotation.y;
            }
        }
    }

    public void Interaction() => StartPotal();
}
