using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private UnityEvent onPress;
    [SerializeField] private bool disposable;
    [HideInInspector] public bool canPress = true;

    private void Awake()
    {
        canPress = true;
    }

    public void PressButron()
    {
        if (canPress) {
            onPress.Invoke();

            if (disposable) canPress = false;
        }
    }
}
