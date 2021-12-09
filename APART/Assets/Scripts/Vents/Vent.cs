using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vent : MonoBehaviour
{
    BoxCollider2D boxCollider;
    CircleCollider2D sphereCollider;

    VentCanvas ventCanvas;

    public bool isUnlocked = false;

    public Transform exitPoint;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        sphereCollider = GetComponent<CircleCollider2D>();
        ventCanvas = transform.root.GetComponent<VentCanvas>();
        exitPoint = transform.GetChild(0).transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isUnlocked = true;
            boxCollider.enabled = true;
            sphereCollider.enabled = false;
        }
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButton(1) && isUnlocked)
        {
            ventCanvas.Enable();
        }
    }
}
