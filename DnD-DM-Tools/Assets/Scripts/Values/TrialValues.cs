using UnityEngine;
using System;

[Serializable]
public class TrialValues
{
    [SerializeField] private string name = "";

    [SerializeField] private string[] tags=null;

    [SerializeField] private float dc = 0;
    [SerializeField] private float cr = 0;
    [SerializeField] private int numofFailures=0;

    [SerializeField] private int checks=0;
    [SerializeField] private Pace checkPace=Pace.None;
    [SerializeField] private int deadline=0;
    [SerializeField] private Pace deadlinePace=Pace.None;

    [SerializeField] private string goalText = "";

    [SerializeField] private TrialOutcomeValues[] outcomes=null;
    [SerializeField] private TrialTaskValues[] tasks=null;

    public string Name => name;

    public string[] Tags => tags;

    public string DC => dc.ToString("F1");
    public string CR => cr.ToString("F1");
    public int NumofFailures => numofFailures;

    public string CheckPace => checks + " per " + Pace2String(checkPace);
    public string Deadline => deadline + " " + Pace2String(deadlinePace) + ((deadline==1)?"":"s");
    private string Pace2String(Pace _value) => Enum.GetName(typeof(Pace), _value);

    public string GoalText => goalText;
    public TrialOutcomeValues[] Outcomes => outcomes;
    public TrialTaskValues[] Tasks => tasks;

}
