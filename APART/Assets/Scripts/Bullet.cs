using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float fireForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "Boss")
        {
            if (collision.gameObject.CompareTag("Head"))
            {
                Destroy(gameObject);
                DamageCanvasSpawner.instance.SpawnDamageText(20, collision.contacts[0].point);
                
                PorqinsManager.instance.DamageFlash(new MeshRenderer[] { collision.gameObject.GetComponent<MeshRenderer>() });
                
            }
            else if (collision.gameObject.CompareTag("Body"))
            {
                Destroy(gameObject);
                DamageCanvasSpawner.instance.SpawnDamageText(10, collision.contacts[0].point);
                PorqinsManager.instance.DamageFlash(new MeshRenderer[] { collision.gameObject.GetComponent<MeshRenderer>() });
                
            }
            else if (collision.gameObject.CompareTag("FrontLegs"))
            {
                Destroy(gameObject);
                DamageCanvasSpawner.instance.SpawnDamageText(5, collision.contacts[0].point);
                MeshRenderer[] legColliders = collision.transform.parent.GetComponentsInChildren<MeshRenderer>();
                PorqinsManager.instance.DamageFlash(legColliders);
                
            }
            else if (collision.gameObject.CompareTag("BackLegs"))
            {
                Destroy(gameObject);
                DamageCanvasSpawner.instance.SpawnDamageText(5, collision.contacts[0].point);
                MeshRenderer[] legColliders = collision.transform.parent.GetComponentsInChildren<MeshRenderer>();
                PorqinsManager.instance.DamageFlash(legColliders);
                
            }
        }
    }
}
