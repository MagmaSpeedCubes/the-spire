using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


[System.Serializable]
public class Infographic : MonoBehaviour
{

    public string type;
    protected float value;
    public void setValue(float newValue)
    {
        float oldValue = value;
        value = newValue;
        updateInfo(oldValue);
    }

    public float getValue()
    {
        return value;
    }

    public void changeValue(float difference)
    {
        setValue(value + difference);
    }

    virtual protected void updateInfo(float oldValue)
    {

    }
}
[System.Serializable]
public class Interval
{
    public float lowerBound;
    public float upperBound;
}

[System.Serializable]
public class IntervalFloat : Interval
{
    public float valueInInterval;

}

