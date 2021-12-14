using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PickupTypes
{
    Ammo,
    Health
}

public class Pickup : MonoBehaviour
{
    public PickupTypes type;
    public int value;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (collision.CompareTag("Player"))
        {

            if (type == PickupTypes.Ammo)
            {
                print("Giving Ammo");
                PlayerWeapon playerW = FindObjectOfType<PlayerWeapon>();
                playerW.GiveAmmo(value);
            }

            if (type == PickupTypes.Health)
            {
                print("Healing");
                Player player = collision.gameObject.GetComponent<Player>();
                player.Heal(value);
            }
        }
    }
}
