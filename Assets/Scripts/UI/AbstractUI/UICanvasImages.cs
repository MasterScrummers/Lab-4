using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasImages : MonoBehaviour
{
    protected List<Image> images;
    protected VariableController varController;
    protected int prevValue;

    protected virtual void Start()
    {
        images = new List<Image>();
        varController = DoStatic.GetGameController().GetComponent<VariableController>();
        foreach (Transform child in DoStatic.GetChildren(transform))
        {
            Image image = child.GetComponent<Image>();
            if (image != null)
            {
                images.Add(image);
            }
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
        foreach (Image image in images)
        {
            image.enabled = value++ < newValue;
        }
    }
}
