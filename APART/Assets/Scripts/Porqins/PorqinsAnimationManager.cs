using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PorqinsAnimationManager : MonoBehaviour
{
    private Animator animator;

    public CameraShake cameraShake;

    public Toggle camShakeToggle;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //hey a shockwave would be kinda cool
    //dodge projectiles and the sw
    public void SpikeLaunch()
    {
        animator.SetTrigger("SpikeLaunch");   
    }

    public void GroundPound()
    {
        animator.SetTrigger("GroundPound");
    }

    public void CameraShake()
    {
        if(camShakeToggle.isOn)
        {
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
        
    }

    public void AnimationComplete(string attackName)
    {
        animator.SetTrigger("AnimationComplete");
        DoAttack(attackName);
    }

    public void DoAttack(string attackName)
    {
        GetComponentInParent<PorqinsManager>().Invoke(attackName, 0.1f);
    }
}
