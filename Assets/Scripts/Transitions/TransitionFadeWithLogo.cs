using UnityEngine;
using UnityEngine.UI;

public class TransitionFadeWithLogo : TransitionFade
{
    private Image logo;

    protected override void Start()
    {
        foreach (Transform child in DoStatic.GetChildren(transform))
        {
            logo = child.GetComponent<Image>();
            if (logo)
            {
                logo.color = new Color(1, 1, 1, 0);
                break;
            }
        }

        base.Start();
    }

    protected override void TransitionIn(bool isStartUp)
    {
        base.TransitionIn(isStartUp);
        if (!lerp.isLerping)
        {
            AssignState(WaitingIn);
        }
    }

    protected virtual void WaitingIn(bool isStartUp)
    {
        if (isStartUp)
        {
            lerp.SetValues(0, 1, 0.1f);
            return;
        }

        lerp.Update(Time.deltaTime);

        if (!lerp.isLerping)
        {
            AssignState(LoadingIn);
        }

        if (startFinishingUp)
        {
            AssignState(TransitionOut);
        }
    }

    protected virtual void LoadingIn(bool isStartUp)
    {
        if (isStartUp)
        {
            lerp.SetValues(0, 1, timeIn);
            return;
        }

        UpdateAlpha(logo);

        if (!lerp.isLerping && startFinishingUp)
        {
            AssignState(LoadingOut);
        }
    }

    protected virtual void LoadingOut(bool isStartUp)
    {
        if (isStartUp)
        {
            lerp.SetValues(1, 0, timeOut);
            return;
        }

        UpdateAlpha(logo);

        if (!lerp.isLerping)
        {
            AssignState(TransitionOut);
        }
    }
}
