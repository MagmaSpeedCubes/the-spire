using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIInput : MonoBehaviour
{
    [SerializeField] protected string scriptOfVariable;
    [SerializeField] protected string variableToChange;
    [SerializeField] protected string prefix, suffix;
    [SerializeField] protected Image imageInfographic;
    [SerializeField] protected List<NumberedSprite> infoSprites = new List<NumberedSprite>();
    [SerializeField] protected Chart chart;
    [SerializeField] protected TextMeshProUGUI textObject;
    [SerializeField] protected List<float> textFontSizes = new List<float>();

    
    void Update()
    {
        updateInfographics(ReflectionCaller.GetVariableValue(scriptOfVariable, variableToChange));
    }
    protected void setValue(object value)
    {
        ReflectionCaller.SetVariableValue(scriptOfVariable, variableToChange, value);
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
        foreach (NumberedSprite spr in infoSprites)
        {
            if ((float)value >= spr.beginValue && (float)value <= spr.endValue)
            {
                imageInfographic.sprite = spr.sprite;
                break;
            }
        }
        //image updates no matter info level

        if (chart != null)
        {
            chart.setValue((float)value);
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
            displayText = "";
            //do not display numbers in aesthetic mode
        }
        else if (infoLevel == 0)
        {
            displayText = prefix + value + suffix;
        }
        else if (infoLevel == 1)
        {
            displayText = prefix + value + suffix;
        }
        else if (infoLevel == 2)
        {

            displayText += "Value: " + value + "\n";
            displayText += "scriptOfVariable: " + scriptOfVariable + ", ";
            displayText += "variableToChange: " + variableToChange + ", ";
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
