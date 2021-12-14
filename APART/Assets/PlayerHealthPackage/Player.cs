using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Material material;
    private Color materialTintColor;

    [SerializeField] private Inventory inv;

    public void Heal(int healAmount)
    {
        HeartsVisual.heartsHealthSystemStatic.Heal(healAmount);
    }

    //private void DamageFlash()
    //{
    //    materialTintColor = new Color(1, 0, 0, 1f);
    //    Material.SetColor("_Tint", materialTintColor);
    //}

    public void Damage(int damageAmount)
    {
        HeartsVisual.heartsHealthSystemStatic.Damage(damageAmount);
    }

    private void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            inv.UpdateSlotSelection(0);
        }
        if(Input.GetKeyDown("2"))
        {
            inv.UpdateSlotSelection(1);
        }
    }
}
