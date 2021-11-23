using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageCanvasSpawner : MonoBehaviour
{
    public TextMeshProUGUI damageTextPrefab;
    public static DamageCanvasSpawner instance;
    public Camera cam;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnDamageText(int damage, Vector3 pos)
    {
        Vector3 screenPos = cam.WorldToScreenPoint(pos);

        TextMeshProUGUI damageText = Instantiate(damageTextPrefab, screenPos, Quaternion.identity, this.transform);
        
        damageText.text = damage.ToString();
        damageText.gameObject.GetComponent<Animator>().SetTrigger("Play");
        SegmentedHealthBar.instance.UpdateHealthBar(damage);
        
    }
}
