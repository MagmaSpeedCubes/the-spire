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
        SoundHandler.playSound("scrollbarMove", ProfileStats.masterVolume * ProfileStats.uiVolume / 10000f);
    }

    protected float CalculateScrollbarValue()
    {
        float raw = scrollbar.value;

        raw = raw * endValue + (1 - raw) * startValue;

        return raw;


    }

    // override protected string generateDisplayText(object value)
    // {
    //     string displayText = base.generateDisplayText(value);
    //     int infoLevel = ProfileStats.infoLevel;
    //     if (infoLevel == 2)
    //     {
    //         displayText += "startValue: " + startValue + ", ";
    //         displayText += "endValue: " + endValue + ", ";
    //         displayText += "roundingPrecision: " + roundingPrecision + ", ";
    //     }
    //     return displayText;

    // }


    
    
}
