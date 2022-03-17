using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public abstract class UICounter : MonoBehaviour
{
    protected string counterName; //The name of the counter
    protected Text UIText; //The text component of the UI
    protected VariableController varController; //The variable controller reference.
    private object prevValue; //The previous value of the counter value.

    protected virtual void Start()
    {
        UIText = GetComponent<Text>();
        varController = GameObject.FindGameObjectWithTag("GameController").GetComponent<VariableController>();
    }

    protected void UpdateUI(object newValue)
    {
        if (prevValue != newValue)
        {
            UIText.text = counterName + "\n" + newValue;
            prevValue = newValue;
        }
    }
}
