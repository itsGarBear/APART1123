using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentTeleporter : MonoBehaviour
{
    public PlayerController player;
    [SerializeField] Vent myVent;
    [SerializeField] VentCanvas ventCanvas;
    public void Teleport()
    {
        print("clicked: " + transform.name);
        player.transform.position = myVent.exitPoint.position;
        ventCanvas.Disable();
    }
}
