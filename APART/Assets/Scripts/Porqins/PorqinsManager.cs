using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorqinsManager : MonoBehaviour
{
    //Spikes
    [Header("Spikes")]
    public Transform[] spikeLaunchers;
    public GameObject spike;
    public float fireForce = 10f;

    //Animations
    private PorqinsAnimationManager porqinsAnimation;

    //Damage Flash
    [Header("Components")]
    private bool flashingDMG;

    public static PorqinsManager instance;

    private void Awake()
    {
        instance = this;
        porqinsAnimation = GetComponentInChildren<PorqinsAnimationManager>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageFlash(MeshRenderer[] meshRenderers)
    {
        if (flashingDMG)
            return;

        StartCoroutine(DamageFlashCoRoutine());

        IEnumerator DamageFlashCoRoutine()
        {
            flashingDMG = true;

            Color defaultColor = Color.white;
            foreach (MeshRenderer mr in meshRenderers)
            {
                defaultColor = mr.material.color;
                mr.material.color = Color.red;
            }
            
            yield return new WaitForSeconds(0.1f);

            foreach (MeshRenderer mr in meshRenderers)
            {
                mr.material.color = defaultColor;
            }

            flashingDMG = false;
        }
    }
    
}
