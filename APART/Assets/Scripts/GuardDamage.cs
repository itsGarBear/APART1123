using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDamage : MonoBehaviour
{
    public int attackDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.Damage(attackDamage);
        }
    }
}
