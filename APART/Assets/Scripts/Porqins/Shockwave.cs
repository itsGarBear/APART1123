using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    public Animator animator;

    public void StartScaling()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Scale");
    }
}
