using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrialStatBlockVisulizer : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private TrialDataSource data = null;
    [Header("Name")]
    [SerializeField] private TMP_Text Name = null;
    [Header("Tags")]
    [SerializeField] private GameObject tagPrefab = null;
    [SerializeField] private Transform tagContainer = null;
    private Pooler tagPool;
    private List<TagVisulizer> activeTags = new List<TagVisulizer>();
    [Header("Failure Buttons")]
    [SerializeField] private GameObject failurePrefab = null;
    [SerializeField] private Transform failureContainer = null;
    private Pooler failurePool;
    private List<GameObject> activefailure = new List<GameObject>();
    [Header("")]
    [SerializeField] private TMP_Text dc = null;
    [SerializeField] private TMP_Text cr = null;
    [SerializeField] private TMP_Text pace = null;
    [SerializeField] private TMP_Text deadline = null;
    [Header("Goal and Outcomes")]
    [SerializeField] private TMP_Text goal = null;
    [SerializeField] private GameObject outcomePrefab = null;
    [SerializeField] private Transform outcomeContainer = null;
    private Pooler outcomePool;
    private List<OutcomeVisulizer> activeoutcomes = new List<OutcomeVisulizer>();
    [Header("Tasks")]
    [SerializeField] private GameObject taskPrefab = null;
    [SerializeField] private Transform taskContainer = null;
    private Pooler taskPool;
    private List<TaskVisulizer> activeTasks = new List<TaskVisulizer>();

    private void Awake()
    {
        //tagPool = new Pooler(tagPrefab, 1, tagContainer);
        //failurePool = new Pooler(failurePrefab, 1, failureContainer);
        //outcomePool = new Pooler(outcomePrefab, 1, outcomeContainer);
        //taskPool = new Pooler(taskPrefab, 1, taskContainer);
        if (tagPool == null)
            tagPool = new Pooler(tagPrefab, 1, tagContainer);
        FreeTags();

        if (failurePool == null)
            failurePool = new Pooler(failurePrefab, 1, failureContainer);
        FreeFailures();

        if (outcomePool == null)
            outcomePool = new Pooler(outcomePrefab, 1, outcomeContainer);
        FreeOutcomes();

        if (taskPool == null)
            taskPool = new Pooler(taskPrefab, 1, taskContainer);
        FreeTasks();

        RefreshVisulizer();
    }

    private void RefreshVisulizer()
    {
        Name.text = data.selectedTrial.Name;
       

        int length = data.selectedTrial.Tags.Length;
        for (int i = 0; i < length; i++)
        {
            activeTags.Add(tagPool.Get().GetComponent<TagVisulizer>());
            activeTags[i].SetName = data.selectedTrial.Tags[i];
        }

        length = data.selectedTrial.NumofFailures;
        for (int i = 0; i < length; i++)
            activefailure.Add(failurePool.Get());

        dc.text = data.selectedTrial.DC;
        cr.text = data.selectedTrial.CR;
        pace.text = data.selectedTrial.CheckPace;
        deadline.text = data.selectedTrial.Deadline;

        goal.text = data.selectedTrial.GoalText;
        length = data.selectedTrial.Outcomes.Length;
        for (int i = 0; i < length; i++)
        {
            activeoutcomes.Add(outcomePool.Get().GetComponent<OutcomeVisulizer>());
            activeoutcomes[i].SetOutcome(i, data.selectedTrial.Outcomes[i],i==length-1);
        }

        length = data.selectedTrial.Tasks.Length;
        for (int i = 0; i < length; i++)
        {
            activeTasks.Add(taskPool.Get().GetComponent<TaskVisulizer>());
            activeTasks[i].SetTask(i, data.selectedTrial.Tasks[i]);
        }

    }

    private void FreeTags()
    {
        int length = activeTags.Count;
        for (int i = 0; i < length; i++)
            tagPool.Free(activeTags[i].gameObject);
        activeTags.Clear();
    }

    private void FreeFailures()
    {
        int length = activefailure.Count;
        for (int i = 0; i < length; i++)
            failurePool.Free(activefailure[i]);
        activefailure.Clear();
    }

    private void FreeOutcomes()
    {
        int length = activeoutcomes.Count;
        for (int i = 0; i < length; i++)
            outcomePool.Free(activeoutcomes[i].gameObject);
        activeoutcomes.Clear();
    }

    private void FreeTasks()
    {
        int length = activeTasks.Count;
        for (int i = 0; i < length; i++)
            taskPool.Free(activeTasks[i].gameObject);
        activeTasks.Clear();
    }
}
