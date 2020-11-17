using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutcomeVisulizer : MonoBehaviour
{
    [SerializeField] private TMP_Text failures = null;
    [SerializeField] private TMP_Text outcome = null;
    [SerializeField] private Image background = null;
    [SerializeField] private Color clr = new Color(0, 0, 0, 0);
    [SerializeField] private Material roundedCornerMat = null;
    [SerializeField] private Vector4 roundness = Vector4.zero;

    public void SetOutcome(int _index, TrialOutcomeValues _outcome, bool _islast)
    {
        failures.text = _outcome.MinMaxFailures();
        outcome.text = _outcome.TrialOutcome();
        if (_index % 2 == 0)
            background.color = clr;
        if (_islast)
        {
            GetComponent<Image>().material = roundedCornerMat;
            gameObject.AddComponent<ImageWithIndependentRoundedCorners>();
            ImageWithIndependentRoundedCorners component = gameObject.GetComponent<ImageWithIndependentRoundedCorners>();
            component.material = roundedCornerMat;
            component.r = roundness;
        }



    }
}
