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

    Color inVulnColor = new Color(255, 195, 0);

    private void Awake()
    {
        instance = this;
    }

    public void SpawnDamageText(int damage, Vector3 pos, bool useGoldText)
    {
        Vector3 screenPos = cam.WorldToScreenPoint(pos);

        TextMeshProUGUI damageText = Instantiate(damageTextPrefab, screenPos, Quaternion.identity, this.transform);

        if (useGoldText) damageText.color = inVulnColor;
        else damageText.color = Color.red; 

        damageText.text = damage.ToString();
        damageText.gameObject.GetComponent<Animator>().SetTrigger("Play");
        //SegmentedHealthBar.instance.UpdateHealthBar(damage);
        
    }
}
