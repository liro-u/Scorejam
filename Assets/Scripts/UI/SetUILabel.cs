using TMPro;
using UnityEngine;

public class SetUILabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] string prefix = "";
    [SerializeField] string sufix = "";
    public void SetLabel(float value)
    {
        label.text = prefix + value.ToString() + sufix;
    }
}
