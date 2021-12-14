using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public Animator fadeToBlack;

    public GameObject minimap;
    public GameObject ventMap;
    public Inventory inventory;

    public GameObject closedRodentCages;

    public static PlayerSwitcher instance;
    private void Start()
    {
        instance = this;
    }
    public void LeverPulled()
    {
        fadeToBlack.SetBool("FadeIn", true);
    }
    public void FinishedFade()
    {
        print("done");
        //RESET IT ALL
        Time.timeScale = 0;

        PlayerController.myPlayer.isCara = false;
        PlayerController.myPlayer.transform.position = transform.root.position;

        PlayerController.myPlayer.SwitchCharacterSprites();

        PlayerController.myPlayer.gameObject.GetComponent<Player>().Heal(20);

        minimap.GetComponent<MiniMap>().ResetMiniMap();
        ventMap.GetComponent<VentCanvas>().ResetVentMaps();

        closedRodentCages.SetActive(false);

        RodentSpawner.instance.SpawnAnimals();

        inventory.ResetInventory();

        Time.timeScale = 1;

    }

    public void FadeToGame()
    {
        fadeToBlack.SetBool("FadeIn", false);
        fadeToBlack.SetBool("FadeOut", true);

        
        //give all ammo
    }

    public void StartAlice()
    {
        print("alice turn");
    }

    public void AnimationComplete(string name)
    {
        fadeToBlack.SetBool(name, false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LeverPulled();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            FadeToGame();
        }
    }
}
