using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentCanvas : MonoBehaviour
{
    public GameObject ventMapPanel;
    public List<Vent> vents;
    public List<VentTeleporter> mapVents;

    public void Enable()
    {
        mapVents[0].player.canShoot = false;
        foreach (Vent v in vents)
        {
            if(v.isUnlocked)
            {
                mapVents[vents.IndexOf(v)].gameObject.SetActive(true);
            }
        }

        ventMapPanel.SetActive(true);
    }

    public void Disable()
    {
        ventMapPanel.SetActive(false);
        mapVents[0].player.canShoot = true;
    }

    private void LateUpdate()
    {
        //click outside the panel
        //if (ventMapPanel.activeSelf && Input.GetMouseButtonDown(0) && !RectTransformUtility.RectangleContainsScreenPoint(ventMapPanel.GetComponent<RectTransform>(), Input.mousePosition, Camera.main))
        if (ventMapPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            Disable();
        }
    }
}
