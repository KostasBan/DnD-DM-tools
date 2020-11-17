using UnityEngine;
using System;

[Serializable]
public class TrialTaskValues
{
    [SerializeField] private string name = "";
    [SerializeField] private string info = "";
    [SerializeField] private int numofSuccesses = 0;

    public string Name => name;
    public string Info => info;
    public int NumofSuccesses => numofSuccesses;
}
