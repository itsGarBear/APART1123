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
    private MeshRenderer[] meshRenderers;
    //Damage Canvas
    public List<Transform> damageCanvasTransforms;

    public static PorqinsManager instance;

    private void Awake()
    {
        instance = this;
        porqinsAnimation = GetComponentInChildren<PorqinsAnimationManager>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            porqinsAnimation.SpikeLaunch();
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            porqinsAnimation.GroundPound();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            LaunchSpikes();
        }
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
    

    //called as Animation Event
    public void LaunchSpikes()
    {
        foreach (Transform t in spikeLaunchers)
        {
            GameObject go = Instantiate(spike, t.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(t.transform.up * fireForce, ForceMode.Impulse);
        }
    }

    //called as Animation Event
    public void GroundPound()
    {
        ShockwaveSpawner.instance.SpawnShockWave();
    }
}
