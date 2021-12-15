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

    public bool isLethal;

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
                    {
                        //invulnerable color = 0, lethal = 1, nonlethal = 2
                        DamageCanvasSpawner.instance.SpawnDamageText(bossHeadShotDamage, collision.contacts[0].point, 0);
                    }
                    else
                    {
                        if (isLethal)
                        {
                            DamageCanvasSpawner.instance.SpawnDamageText(bossHeadShotDamage, collision.contacts[0].point, 1);
                            PorqinsManager.instance.DamageFlash(new SpriteRenderer[] { collision.gameObject.GetComponent<SpriteRenderer>() }, true);
                            segmentedHealthBar.UpdateHealthBar(bossHeadShotDamage, true);
                        }
                        else
                        {
                            DamageCanvasSpawner.instance.SpawnDamageText(bossHeadShotDamage, collision.contacts[0].point, 2);
                            PorqinsManager.instance.DamageFlash(new SpriteRenderer[] { collision.gameObject.GetComponent<SpriteRenderer>() }, false);
                            segmentedHealthBar.UpdateHealthBar(bossHeadShotDamage, false);
                        }
                        
                    }

                }
                else if (collision.gameObject.CompareTag("Body"))
                {
                    //if (segmentedHealthBar.isInvulnerable)
                    //    DamageCanvasSpawner.instance.SpawnDamageText(bossBodyShotDamage, collision.contacts[0].point, true);
                    //else
                    //    DamageCanvasSpawner.instance.SpawnDamageText(bossBodyShotDamage, collision.contacts[0].point, false);

                    //PorqinsManager.instance.DamageFlash(new SpriteRenderer[] { collision.gameObject.GetComponent<SpriteRenderer>() });
                    //segmentedHealthBar.UpdateHealthBar(bossBodyShotDamage);
                    if (segmentedHealthBar.isInvulnerable)
                    {
                        //invulnerable color = 0, lethal = 1, nonlethal = 2
                        DamageCanvasSpawner.instance.SpawnDamageText(bossBodyShotDamage, collision.contacts[0].point, 0);
                    }
                    else
                    {
                        if (isLethal)
                        {
                            DamageCanvasSpawner.instance.SpawnDamageText(bossBodyShotDamage, collision.contacts[0].point, 1);
                            PorqinsManager.instance.DamageFlash(new SpriteRenderer[] { collision.gameObject.GetComponent<SpriteRenderer>() }, true);
                            segmentedHealthBar.UpdateHealthBar(bossBodyShotDamage, true);
                        }
                        else
                        {
                            DamageCanvasSpawner.instance.SpawnDamageText(bossBodyShotDamage, collision.contacts[0].point, 2);
                            PorqinsManager.instance.DamageFlash(new SpriteRenderer[] { collision.gameObject.GetComponent<SpriteRenderer>() }, false);
                            segmentedHealthBar.UpdateHealthBar(bossBodyShotDamage, false);
                        }

                    }

                }
                else if (collision.gameObject.CompareTag("FrontLegs"))
                {
                    //if (segmentedHealthBar.isInvulnerable)
                    //    DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, true);
                    //else
                    //    DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, false);

                    //SpriteRenderer[] legSprites = collision.transform.parent.GetComponentsInChildren<SpriteRenderer>();
                    //PorqinsManager.instance.DamageFlash(legSprites);
                    //segmentedHealthBar.UpdateHealthBar(bossLegShotDamage);

                    if (segmentedHealthBar.isInvulnerable)
                    {
                        //invulnerable color = 0, lethal = 1, nonlethal = 2
                        DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, 0);
                    }
                    else
                    {
                        if (isLethal)
                        {
                            DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, 1);
                            PorqinsManager.instance.DamageFlash(new SpriteRenderer[] { collision.gameObject.GetComponent<SpriteRenderer>() }, true);
                            segmentedHealthBar.UpdateHealthBar(bossLegShotDamage, true);
                        }
                        else
                        {
                            DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, 2);
                            PorqinsManager.instance.DamageFlash(new SpriteRenderer[] { collision.gameObject.GetComponent<SpriteRenderer>() }, false);
                            segmentedHealthBar.UpdateHealthBar(bossLegShotDamage, false);
                        }

                    }

                }
                else if (collision.gameObject.CompareTag("BackLegs"))
                {
                    //if (segmentedHealthBar.isInvulnerable)
                    //    DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, true);
                    //else
                    //    DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, false);

                    //SpriteRenderer[] legSprites = collision.transform.parent.GetComponentsInChildren<SpriteRenderer>();
                    //PorqinsManager.instance.DamageFlash(legSprites);
                    //segmentedHealthBar.UpdateHealthBar(bossLegShotDamage);

                    if (segmentedHealthBar.isInvulnerable)
                    {
                        //invulnerable color = 0, lethal = 1, nonlethal = 2
                        DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, 0);
                    }
                    else
                    {
                        if (isLethal)
                        {
                            DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, 1);
                            PorqinsManager.instance.DamageFlash(new SpriteRenderer[] { collision.gameObject.GetComponent<SpriteRenderer>() }, true);
                            segmentedHealthBar.UpdateHealthBar(bossLegShotDamage, true);
                        }
                        else
                        {
                            DamageCanvasSpawner.instance.SpawnDamageText(bossLegShotDamage, collision.contacts[0].point, 2);
                            PorqinsManager.instance.DamageFlash(new SpriteRenderer[] { collision.gameObject.GetComponent<SpriteRenderer>() }, false);
                            segmentedHealthBar.UpdateHealthBar(bossLegShotDamage, false);
                        }

                    }

                }
            }
        }

        else if (PlayerController.myPlayer.isCara)
        {
            if(collision.gameObject.CompareTag("SecurityCamera"))
            {
                print("camera disabled");
                collision.gameObject.transform.parent.parent.GetComponent<SecurityCamera>().isDisabled = true;
            }
        }
            
    }

}
