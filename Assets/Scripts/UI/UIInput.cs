using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIInput : MonoBehaviour
{
    [SerializeField] protected string scriptOfVariable;
    [SerializeField] protected string variableToChange;
    [SerializeField] protected string variableType;
    [SerializeField] protected string prefix, suffix;
    [SerializeField] protected Image imageInfographic;
    [SerializeField] protected List<NumberedSprite> infoSprites = new List<NumberedSprite>();

    [SerializeField] protected Chart chart;
    [SerializeField] protected TextMeshProUGUI textObject;
    [SerializeField] protected List<float> textFontSizes = new List<float>();
    protected int spriteIndex;

    
    void Update()
    {
        updateInfographics(ReflectionCaller.GetVariableValue(scriptOfVariable, variableToChange));
    }
    protected void setValue(object value)
    {
        ReflectionCaller.SetVariableValue(scriptOfVariable, variableToChange, (float)value);
        updateInfographics(value);
    }

    protected void changeValue(float difference)
    {
        float initialValue = (float)getValue();
        object newValue = initialValue + difference;
        setValue(newValue);
    }

    protected object getValue()
    {
        return ReflectionCaller.GetVariableValue(scriptOfVariable, variableToChange);
    }



    protected void updateInfographics(object value)
    {

        int infoLevel = ProfileStats.infoLevel;
        //show basic stats without using numbers
        switch (variableType)
        {
            case "float":
                float fv = (float)value;

                foreach (NumberedSprite spr in infoSprites)
                {
                    
                    if (fv >= spr.beginValue && fv <= spr.endValue)
                    {
                        imageInfographic.sprite = spr.sprite;
                        spriteIndex = infoSprites.IndexOf(spr);
                        break;
                    }
                }

                if (chart != null)
                {
                    chart.setValue(fv);
                }
                break;
            case "int":
                int iv = (int)value;

                foreach (NumberedSprite spr in infoSprites)
                {
                    
                    if (iv >= spr.beginValue && iv <= spr.endValue)
                    {
                        imageInfographic.sprite = spr.sprite;
                        spriteIndex = infoSprites.IndexOf(spr);
                        break;
                    }
                }

                if (chart != null)
                {
                    chart.setValue(iv);
                }
                break;
        }


        textObject.text = generateDisplayText(value);
        textObject.fontSize = textFontSizes[infoLevel + 1];



    }
    
    virtual protected string generateDisplayText(object value)
    {
        string displayText = "";
        int infoLevel = ProfileStats.infoLevel;

        if (infoLevel == -1)
        {
            displayText = infoSprites[spriteIndex].name;
        }
        else if (infoLevel == 0)
        {
            displayText = infoSprites[spriteIndex].name;
        }
        else if (infoLevel == 1)
        {
            displayText = infoSprites[spriteIndex].name + ", " + prefix + value + suffix;
        }
        else if (infoLevel == 2)
        {

            displayText += "Value: " + infoSprites[spriteIndex].name + ", " + prefix + value + suffix + ", ";
            displayText += "scriptOfVariable: " + scriptOfVariable + ", ";
            displayText += "variableToChange: " + variableToChange + ", ";
            displayText += "variableType: " + variableType + ", ";
            if (chart != null)
            {
                displayText += "chartType: " + chart.type + ", ";
            }
            else
            {
                displayText += "chartType: None, ";
            }
            displayText += "textFontSizes: " + textFontSizes + ", ";
            


        }

        return displayText;
        
    }
    
}
