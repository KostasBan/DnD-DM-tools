using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutcomeVisulizer : MonoBehaviour
{
    [SerializeField] private TMP_Text failures = null;
    [SerializeField] private TMP_Text outcome = null;
    [SerializeField] private Image background = null;
    [SerializeField] private Color clr = new Color(0, 0, 0, 0);
    
    public void SetOutcome(int _index, TrialOutcomeValues _outcome)
    {
        failures.text = _outcome.MinMaxFailures();
        outcome.text = _outcome.TrialOutcome();
        if (_index % 2 == 1)
            background.color = clr;
    }
}
