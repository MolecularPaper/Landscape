using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewGlitch : MonoBehaviour
{
    [SerializeField] private GameObject mesh;

    void Awake() 
    {
        mesh.SetActive(false);
    }

    public void EnbledGlitch() => mesh.SetActive(true);
    public void DisableGlitch() => mesh.SetActive(false);
}
