using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIInput : MonoBehaviour
{
    [SerializeField] protected string scriptOfVariable;
    [SerializeField] protected string variableToChange;

    [SerializeField] protected string variableType;

    [SerializeReference] protected Infographic[] infographics;
    [SerializeField] protected TextMeshProUGUI mainText;
    protected int spriteIndex;

    
    void Update()
    {
        // Debug.Log("Updating " + variableToChange);
        updateInfographics(ReflectionCaller.GetVariableValue(scriptOfVariable, variableToChange));
        // Debug.Log("Update display of " + variableToChange + " to " + ReflectionCaller.GetVariableValue(scriptOfVariable, variableToChange));
    }
    protected void setValue(object value)
    {
        ReflectionCaller.SetVariableValue(scriptOfVariable, variableToChange, (float)value);
        ProfileStats.SavePrefs();
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



        switch (variableType)
        {
            case "float":
                float fv = (float)value;



                foreach (Infographic graph in infographics)
                {
                    graph?.setValue(fv);

                }
                break;
            case "int":
                int iv = (int)value;

                foreach (Infographic graph in infographics)
                {
                    graph?.setValue(iv);

                }

                break;
        }
        

    }
    
    // virtual protected string generateDisplayText(object value)
    // {
     

    //     if (infoLevel == -1)
    //     {
            
    //     }
    //     else if (infoLevel == 0)
    //     {
    //         displayText = infoSprites[spriteIndex].name;
    //     }
    //     else if (infoLevel == 1)
    //     {
    //         displayText = infoSprites[spriteIndex].name + ", " + prefix + value + suffix;
    //     }
    //     else if (infoLevel == 2)
    //     {

    //         displayText += "Value: " + infoSprites[spriteIndex].name + ", " + prefix + value + suffix + ", ";
    //         displayText += "scriptOfVariable: " + scriptOfVariable + ", ";
    //         displayText += "variableToChange: " + variableToChange + ", ";
    //         displayText += "variableType: " + variableType + ", ";
    //         if (infographic != null)
    //         {
    //             displayText += "infographicType: " + infographic.type + ", ";
    //         }
    //         else
    //         {
    //             displayText += "infographicType: None, ";
    //         }
    //         displayText += "textFontSizes: " + textFontSizes + ", ";
            


    //     }

    //     return displayText;
        
    // }
    
}
