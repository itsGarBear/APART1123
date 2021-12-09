using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorqinsBossFight : MonoBehaviour
{
    SegmentedHealthBar segmentedHealthBar;

    public static PorqinsBossFight instance;
    private PorqinsAnimationManager porqinsAnimation;

    public int numRepeatShockWaves = 3;

    public int currPhase = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        segmentedHealthBar = transform.root.GetComponentInChildren<SegmentedHealthBar>();
        porqinsAnimation = GetComponentInChildren<PorqinsAnimationManager>();
    }
    //Actual Attacks
    public void PhaseAttacks()
    {
        if (currPhase == 1)
        {
            QuillPhase(3);
        }
        else if (currPhase == 2)
        {
            QuillPhase(6);
        }
        else if (currPhase == 3)
        {
            ShockWavePhase();
        }
        else if (currPhase == 4)
        {
            RollPhase();
        }

        currPhase++;
    }




    //Animations
    public void StartPhase()
    {
        if (currPhase == 1)
        {
            porqinsAnimation.SpikeLaunch();
        }
        else if (currPhase == 2)
        {
            porqinsAnimation.SpikeLaunch();
        }
        else if (currPhase == 3)
        {
            porqinsAnimation.GroundPound();
        }
        else if (currPhase == 4)
        {
            //CHANGE ME
            //porqinsAnimation.GroundPound();
        }
    }
    private void SpikeBallArmor()
    {

    }

    //first and second phase
    public void QuillPhase(int numberOfSpikesToLaunchFrom)
    {
        for (int i = 0; i < numberOfSpikesToLaunchFrom; i++)
        {
            Transform t = PorqinsManager.instance.spikeLaunchers[i];
            GameObject go = Instantiate(PorqinsManager.instance.spike, t.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().AddForce(t.transform.up * PorqinsManager.instance.fireForce, ForceMode2D.Impulse);
        }
    }

    //third phase
    private void ShockWavePhase()
    {
        //for(int i = 0; i < numRepeatShockWaves; i++)
       // {
            ShockwaveSpawner.instance.SpawnShockWave();
        //}
        
        //ShockwaveSpawner.instance.CancelInvoke();
    }

    //fourth phase
    private void RollPhase()
    {
        print("roll phase");
    }
}
