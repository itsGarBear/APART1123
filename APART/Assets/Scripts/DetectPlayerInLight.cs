using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerInLight : MonoBehaviour
{
    public Material cannotSeePlayerColor;
    public Material canSeePlayerColor;

    PlayerController player;

    //Can see player
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().material = canSeePlayerColor;
            player = collision.gameObject.transform.root.GetComponent<PlayerController>();
            transform.root.GetComponent<SecurityCamera>().FoundPlayer(player);
        }
    }

    //Cannot see player
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().material = cannotSeePlayerColor;

            player = collision.gameObject.transform.root.GetComponent<PlayerController>();
            transform.root.GetComponent<SecurityCamera>().LostPlayer(player);
        }
    }
}
