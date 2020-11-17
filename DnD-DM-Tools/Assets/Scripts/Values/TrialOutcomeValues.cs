using UnityEngine;
using System;

[Serializable]
public class TrialOutcomeValues
{
    [SerializeField] private Vector2 minMaxFailures = Vector2.zero;
    [SerializeField] private TrialVictoryType typeofVictory = TrialVictoryType.None;
    [SerializeField] private string info = "";

    public string MinMaxFailures()
    {
        string returnString = "";
        if (minMaxFailures.x == minMaxFailures.y)
            returnString = minMaxFailures.x.ToString();
        else
            returnString = minMaxFailures.x + "-" + minMaxFailures.y;
        return returnString;
    }

    public string TrialOutcome()
    {
        string returnString = "";
        switch (typeofVictory)
        {
            case TrialVictoryType.MajorVictory:
                returnString = "Major Victory";
                break;
            case TrialVictoryType.Victory:
                returnString = "Victory";
                break;
            case TrialVictoryType.MinorVictory:
                returnString = "Minor Victory";
                break;
            case TrialVictoryType.MajorDefeat:
                returnString = "Major Defeat";
                break;
            case TrialVictoryType.Defeat:
                returnString = "Defeat";
                break;
            case TrialVictoryType.MinorDefeat:
                returnString = "Minor Defeat";
                break;
        }
        return "<b>" + returnString + ": </b>" + info;
    }

    public string Info => info;

}