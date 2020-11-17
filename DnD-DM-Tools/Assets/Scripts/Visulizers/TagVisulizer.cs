using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TagVisulizer : MonoBehaviour
{
    [SerializeField] private TMP_Text Name = null;
    public string SetName
    {
        set
        {
            Name.text = value;
        }
    }
}
