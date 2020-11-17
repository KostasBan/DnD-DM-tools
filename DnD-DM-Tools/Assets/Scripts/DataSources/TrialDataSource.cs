using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrialDataSource", menuName = "Datasources/TrialDataSource", order = 1)]
public class TrialDataSource : ScriptableObject
{
    public TrialValues selectedTrial;
    public List<TrialValues> Trials;

    [EasyButtons.Button]
    public void SaveSelectedTrial()
    {
        if (Trials == null)
            Trials = new List<TrialValues>();
        if (Trials.Contains(selectedTrial))
            Trials.Remove(selectedTrial);
        Trials.Add(selectedTrial);

    }
}
