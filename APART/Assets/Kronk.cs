using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kronk : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("PullLever", true);
        }
    }

    public void LeverDown()
    {
        anim.SetBool("PullLever", false);
        PlayerSwitcher.instance.LeverPulled();
    }
}
