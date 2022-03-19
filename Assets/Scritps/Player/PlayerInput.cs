using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput input;

    public FirstPersonControll fpc { get; private set; }

    void Awake()
    {
        input = GetComponent<PlayerInput>();

        fpc = new FirstPersonControll();
    }

    private void OnEnable()
    {
        fpc.Enable();
    }

    private void OnDisable()
    {
        fpc.Disable();
    }
}
