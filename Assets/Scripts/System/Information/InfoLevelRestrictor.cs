using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(CanvasGroup))]
public class InfoLevelRestrictor : MonoBehaviour
{
    public List<Interval> infoIntervals = new List<Interval>();
    //first number is the first lower bound
    //next is the upper bound that closes it
    private CanvasGroup parent;

    void Awake()
    {
        parent = GetComponent<CanvasGroup>();

    }

    void Update()
    {
        float infoLevel = ProfileStats.infoLevel;

        if (!inBounds(infoLevel, infoIntervals))
        {
            parent.alpha = 0f;
        }
        else
        {
            parent.alpha = 1f;
        }

    }
    
    bool inBounds(float infoLevel, List<Interval> infoIntervals)
    {
        bool output = false;
        foreach (Interval range in infoIntervals)
        {
            bool withinLowerBound = range.lowerBound == null || infoLevel >= range.lowerBound;
            bool withinUpperBound = range.upperBound == null || infoLevel <= range.upperBound;

            output = withinLowerBound && withinUpperBound;
            if (output)
            {
                break;
            }
        }
        return output;
    }
    




}

