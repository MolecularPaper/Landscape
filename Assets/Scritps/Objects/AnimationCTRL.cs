using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCTRL : MonoBehaviour
{
    private Animator anim;

    private void Awake() => anim = GetComponent<Animator>();

    public void Play() => anim.SetTrigger("On");
}
