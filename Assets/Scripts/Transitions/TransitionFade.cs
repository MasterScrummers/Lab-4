using UnityEngine;
using UnityEngine.UI;

public class TransitionFade : TransitionBase
{
    protected Lerper lerp;
    private Image background;

    protected override void Start()
    {
        transitionName = "Fade";
        lerp = new Lerper();
        background = GetComponent<Image>();
        base.Start();
    }

    public override void InitiateTransition()
    {
        AssignState(TransitionIn);
    }

    protected virtual void TransitionIn(bool isStartUp)
    {
        if (isStartUp)
        {
            lerp.SetValues(0, 1, timeIn);
            return;
        }

        UpdateAlpha(background);

        if (!lerp.isLerping)
        {
            startLoading = true;
            if (startFinishingUp && this.GetType().Equals(typeof(TransitionFade)))
            {
                AssignState(TransitionOut);
            }
        }
    }

    protected virtual void TransitionOut(bool isStartUp)
    {
        if (isStartUp)
        {
            lerp.SetValues(1, 0, timeOut);
            return;
        }

        UpdateAlpha(background);

        if (!lerp.isLerping)
        {
            AssignState(null);
        }
    }

    protected void UpdateAlpha(Image image)
    {
        lerp.Update(Time.deltaTime);
        if (image)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, lerp.currentValue);
        }
    }
}
