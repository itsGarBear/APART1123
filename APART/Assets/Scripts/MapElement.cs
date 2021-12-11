using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapElement : MonoBehaviour
{
    public Image miniMapImage;
    public BoxCollider2D unlockZone;
    public bool isFound = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isFound = true;
        unlockZone.enabled = false;
    }
}
