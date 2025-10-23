using System;
using System.Reflection;
using UnityEngine;

public class ReflectionCaller : MonoBehaviour
{

    public static void CallFunction(string scriptName, string functionName)
    {
        Type type = Type.GetType(scriptName);
        if (type == null)
        {
            Debug.LogError("Type not found: " + scriptName);
            return;
        }
        MethodInfo method = type.GetMethod(functionName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        if (method == null)
        {
            Debug.LogError("Method not found: " + functionName);
            return;
        }

        object instance = null;
        if (!method.IsStatic)
        {
            // Find the first active instance in the scene
            instance = GameObject.FindObjectOfType(type);
            if (instance == null)
            {
                Debug.LogError("Instance of " + scriptName + " not found in scene.");
                return;
            }
        }

        method.Invoke(instance, null);
    }


    public static object GetVariableValue(string scriptName, string variableName)
    {
        // Get the type
        Type type = Type.GetType(scriptName);
        if (type == null)
        {
            Debug.LogError("Type not found: " + scriptName);
            return null;
        }

        // Try to find the field first
        FieldInfo field = type.GetField(variableName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        // If not found, try property
        PropertyInfo property = null;
        if (field == null)
        {
            property = type.GetProperty(variableName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            if (property == null)
            {
                Debug.LogError("Variable or property not found: " + variableName);
                return null;
            }
        }

        // Prepare instance (for non-static fields/properties)
        object instance = null;
        bool isStatic = field != null ? field.IsStatic : property.GetGetMethod(true).IsStatic;
        if (!isStatic)
        {
            instance = GameObject.FindObjectOfType(type);
            if (instance == null)
            {
                Debug.LogError("Instance of " + scriptName + " not found in scene.");
                return null;
            }
        }

        // Get value
        object value = field != null
            ? field.GetValue(instance)
            : property.GetValue(instance);

        Debug.Log($"Value of {scriptName}.{variableName} = {value}");
        return value;
    }



    public static void SetVariableValue(string scriptName, string variableName, object newValue)
    {
        // Get the type
        Type type = Type.GetType(scriptName);
        if (type == null)
        {
            Debug.LogError("Type not found: " + scriptName);
            return;
        }

        // Try to find the field
        FieldInfo field = type.GetField(variableName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        // Try to find the property if field not found
        PropertyInfo property = null;
        if (field == null)
        {
            property = type.GetProperty(variableName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            if (property == null)
            {
                Debug.LogError("Variable or property not found: " + variableName);
                return;
            }
        }

        // Determine if static or instance
        bool isStatic = field != null ? field.IsStatic : property.GetSetMethod(true).IsStatic;
        object instance = null;
        if (!isStatic)
        {
            instance = GameObject.FindObjectOfType(type);
            if (instance == null)
            {
                Debug.LogError("Instance of " + scriptName + " not found in scene.");
                return;
            }
        }

        // Set the value
        if (field != null)
        {
            field.SetValue(instance, newValue);
        }
        else if (property != null)
        {
            property.SetValue(instance, newValue);
        }

        Debug.Log($"Set {scriptName}.{variableName} = {newValue}");
    }
    
}