using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bullet : MonoBehaviour
{
    private int bossHeadShotDamage = 20;
    private int bossBodyShotDamage = 10;
    private int bossLegShotDamage = 5;
    private int mobHeadShotDamage = 20;
    private int mobBodyShotDamage = 20;

    public Rigidbody2D rb;
    public float fireForce = 10f;
    SegmentedHealthBar segmentedHealthBar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (!PlayerController.myPlayer.isCara)
        {
            if (LayerMask.LayerToName(collision.gameObject.layer) == "Boss")
            {
                segmentedHealthBar = collision.gameObject.transform.root.GetComponentInChildren<SegmentedHealthBar>();

                if (collision.gameObject.CompareTag("Head"))
                {
                    if (segmentedHealthBar.isInvulnerable)
                        DamageCanvasSpawner.instance.SpawnDamageText(bossHeadShotDamage, collision.contacts[0].point, true);
                    else
                        DamageCanvasSpawner.instance.SpawnDamageText(bossHeadShotDamage, collision.contacts[0].point, false);

                    //PorqinsManager.instance.DamageFlash(new MeshRenderer[] { collision.gameObject.GetComponent<MeshRenderer>() });
                    segmentedHealthBar.UpdateHealthBar(bossHeadShotDamage);

                }
                else if (collision.gameObject.CompareTag("Body"))
                {
                    if (segmentedHealthBar.isInvulnerable)
                        DamageCanvasSpawner.instance.SpawnDamageText(bossBodyShotDamage, collision.contacts[0].point, true);
                    else
                        DamageCanvasSpawner.instance.SpawnDamageText(bossBodyShotDamage, collision.contacts[0].point, false);

                    //PorqinsManager.instance.DamageFlash(new MeshRenderer[] { collision.gameObject.GetComponent<MeshRenderer>() });
                    segmentedHealthBar.UpdateHealthBar(bossBodyShotDamage);

                }
                else if (collision.gameObject.CompareTag("FrontLegs"))
                {
                    if (segmentedHealthBar.isInvulnerable)
                        DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, true);
                    else
                        DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, false);

                    //MeshRenderer[] legColliders = collision.transform.parent.GetComponentsInChildren<MeshRenderer>();
                    //PorqinsManager.instance.DamageFlash(legColliders);
                    segmentedHealthBar.UpdateHealthBar(bossLegShotDamage);

                }
                else if (collision.gameObject.CompareTag("BackLegs"))
                {
                    if (segmentedHealthBar.isInvulnerable)
                        DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, true);
                    else
                        DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, false);

                    //MeshRenderer[] legColliders = collision.transform.parent.GetComponentsInChildren<MeshRenderer>();
                    //PorqinsManager.instance.DamageFlash(legColliders);
                    segmentedHealthBar.UpdateHealthBar(bossLegShotDamage);

                }
            }
        }

        else if (PlayerController.myPlayer.isCara)
        {
            if(collision.gameObject.CompareTag("SecurityCamera"))
            {
                print("camera disabled");
                collision.gameObject.transform.root.GetComponent<SecurityCamera>().isDisabled = true;
            }
        }
            
    }

}
