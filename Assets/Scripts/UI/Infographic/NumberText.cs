using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System;
public class NumberText : Infographic
{
    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected string prefix, suffix;
    [SerializeField] protected IntervalFloat[] roundingPrecisionList;

    void Awake()
    {
        type = "Text";
    }

    override protected void updateInfo(float oldValue)
    {
        base.updateInfo(oldValue);

        int roundingPrecision = getRoundingPrecision();
        float roundedValue = Mathf.Floor(value / roundingPrecision + 0.5f) * roundingPrecision;
        animateToValue(oldValue, roundedValue, 0.5f);

    }

    protected void animateToValue(float oldValue, float newValue, float time)
    {
        
        StartCoroutine(animateToValueCoroutine(oldValue, newValue, time));
    }

    protected IEnumerator animateToValueCoroutine(float oldValue, float newValue, float time)
    {

        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            float progression = elapsedTime / time;
            float midValue = oldValue + (newValue - oldValue) * progression;
            int roundingPrecision = getRoundingPrecision();
            float roundedMidValue = Mathf.Floor(midValue / roundingPrecision + 0.5f) * roundingPrecision;

            text.text = prefix + midValue + suffix;
        }
        text.text = prefix + newValue + suffix;




        yield return null;
    }

    protected int getRoundingPrecision()
    {
        int roundingPrecision = 1;
        foreach (IntervalFloat rfr in roundingPrecisionList)
        {
            int infoLevel = ProfileStats.infoLevel;
            if (infoLevel >= rfr.lowerBound || infoLevel <= rfr.upperBound)
            {
                roundingPrecision = (int)rfr.valueInInterval;
                break;
            }


        }
        return roundingPrecision;
    }

}

