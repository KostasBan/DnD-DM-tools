using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskVisulizer : MonoBehaviour
{
    [SerializeField] private TMP_Text index = null;
    [SerializeField] private TMP_Text taskName = null;
    [SerializeField] private TMP_Text taskInfo = null;

    [Header("Buttons")]
    [SerializeField] private GameObject successPrefab = null;
    [SerializeField] private Transform successContainer = null;
    private Pooler successPool;
    private List<GameObject> activesuccesses = new List<GameObject>();

    private void Awake()
    {
        successPool = new Pooler(successPrefab, 1, successContainer);
    }

    public void SetTask(int _index, TrialTaskValues _value)
    {
        index.text = _index.ToString();
        taskName.text = _value.Name;
        taskInfo.text = _value.Info;

        if (successPool == null)
            successPool = new Pooler(successPrefab, 1, successContainer);
        FreeSuccesses();
        int length = _value.NumofSuccesses;
        for (int i = 0; i < length; i++)
            activesuccesses.Add(successPool.Get());       
    }

    private void FreeSuccesses()
    {
        int length = activesuccesses.Count;
        for (int i = 0; i < length; i++)
            successPool.Free(activesuccesses[i]);
        activesuccesses.Clear();
    }
}
