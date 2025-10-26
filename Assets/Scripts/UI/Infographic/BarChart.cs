using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class BarChart : Infographic
{
    [SerializeField] protected Image beginSegment, scaleSegment, endSegment;
    [SerializeField] protected float minValue, maxValue, roundingPrecision;
    [SerializeField] protected float textObject;
    protected Vector2 startPosition, endPosition;
    protected float maxDistance, angle;

    void Awake()
    {
        type = "Bar";
        startPosition = beginSegment.transform.position;
        endPosition = endSegment.transform.position;
        float x = endPosition.x - startPosition.x; 
        float y = endPosition.y - startPosition.y;
        maxDistance = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        angle = Mathf.Atan(y / x);
    }
    protected override void updateInfo(float oldValue)
    {
        base.updateInfo(oldValue);
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



            Vector2 progressPosition = startPosition;
            progressPosition.x += (midValue - minValue) / (maxValue - minValue) * Mathf.Cos(angle);
            progressPosition.y += (midValue - minValue) / (maxValue - minValue) * Mathf.Sin(angle);
            endSegment.transform.position = progressPosition;

            elapsedTime += Time.deltaTime;
        }




        yield return null;
    }
    

}