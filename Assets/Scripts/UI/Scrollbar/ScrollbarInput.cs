using UnityEngine;
using UnityEngine.UI;
using System;
public class ScrollbarInput : UIInput
{
    [SerializeField] protected Scrollbar scrollbar;
    [SerializeField] protected float startValue, endValue;
    [SerializeField] protected float roundingPrecision;
    public void OnScrollbarMove()
    {
        base.setValue(CalculateScrollbarValue());
    }

    protected float CalculateScrollbarValue()
    {
        float raw = scrollbar.value;

        raw = raw * endValue + (1 - raw) * startValue;

        raw /= roundingPrecision;
        raw = Mathf.Floor(raw + 0.5f);
        raw *= roundingPrecision;
        return raw;


    }


    
    
}
