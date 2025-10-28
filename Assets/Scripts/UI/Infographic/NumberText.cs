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

        float roundingPrecision = getRoundingPrecision();
        // Debug.Log("RP:" + roundingPrecision);
        float roundedValue = (int)Mathf.Round(value / roundingPrecision) * roundingPrecision;
        text.text = prefix + roundedValue + suffix;
        // animateToValue(oldValue, roundedValue, 0.5f);

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
            float roundingPrecision = getRoundingPrecision();
            float roundedMidValue = Mathf.Floor(midValue / roundingPrecision + 0.5f) * roundingPrecision;

            text.text = prefix + midValue + suffix;
            elapsedTime += Time.deltaTime;
        }
        




        yield return null;
    }

    protected float getRoundingPrecision()
    {
        float roundingPrecision = 1f;
        foreach (IntervalFloat rfr in roundingPrecisionList)
        {
            // Debug.Log("Checking");
            int infoLevel = (int)ProfileStats.infoLevel;
            // Debug.Log("Info Level: " + infoLevel);
            if (infoLevel >= rfr.lowerBound && infoLevel <= rfr.upperBound)
            {
                
                // Debug.Log(infoLevel + ">= " + rfr.lowerBound);
                // Debug.Log(infoLevel + "<= " + rfr.upperBound);
                roundingPrecision = rfr.valueInInterval;
                break;
            }



        }
        return roundingPrecision;
    }

}

