using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeReset : MonoBehaviour
{
    public PlayerWeapon playerWeapon;
    public void ResetMelee(string name)
    {
        playerWeapon.meleeAnim.SetBool(name, false);
        playerWeapon.canMelee = true;
    }
}
