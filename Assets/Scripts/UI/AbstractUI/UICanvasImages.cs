using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasImages : MonoBehaviour
{
    protected List<Transform> images;
    protected VariableController varController;
    protected int prevValue;

    protected virtual void Start()
    {
        images = new List<Transform>();
        varController = DoStatic.GetGameController().GetComponent<VariableController>();
        foreach (Transform child in DoStatic.GetChildren(transform))
        {
            images.Add(child);
        }
    }

    protected void UpdateDisplay(int newValue)
    {
        if (prevValue == newValue)
        {
            return;
        }

        prevValue = newValue;
        int value = 0;
        foreach (Transform image in images)
        {
            image.gameObject.SetActive(value++ < newValue);
        }
    }
}
