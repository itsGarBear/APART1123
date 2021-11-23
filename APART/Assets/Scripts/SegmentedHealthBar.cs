using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SegmentedHealthBar : MonoBehaviour
{
    public static SegmentedHealthBar instance;
    public TextMeshProUGUI damageText;
    public List<Slider> sliders;
    public int maxHealth = 100;
    private int segmentAmount;
    private int segmentNdx = 0;
    private int currHealthSum = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        damageText.text = maxHealth.ToString();
        segmentAmount = maxHealth / sliders.Count;
        foreach(Slider s in sliders)
        {
            s.maxValue = segmentAmount;
            s.value = segmentAmount;
        }
    }
    public void UpdateHealthBar(int damage)
    {
        if(damage > sliders[segmentNdx].value)
        {
            sliders[segmentNdx].value = 0;
            segmentNdx++;
        }
        else
        {
            sliders[segmentNdx].value -= damage;
            if (sliders[segmentNdx].value == 0)
            {
                segmentNdx++;
            }
        }
        
        foreach(Slider s in sliders)
        {
            currHealthSum += (int)s.value;
        }

        damageText.text = currHealthSum.ToString();
        currHealthSum = 0;
    }
}
