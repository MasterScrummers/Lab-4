using UnityEngine;

/// <summary>
/// 1. TransitionIn (parent, override) - Fades in background
/// 2. CutsceneIn
/// 3. PlayCutscene
/// 4. CutsceneOut
/// 5. WaitingIn (parent)
///     5.1 LoadingIn (parent)
///     5.2 LoadingOut (parent)
/// 6. TransitionOut (parent)
/// </summary>
public class TransitionFadeWithCutscene : TransitionFadeWithLogo
{
    public GameObject cutsceneShipPrefab; //The prefab of the cutscene ship
    public SpriteRenderer[] cutsceneBackground; //The gameObject in the scene of the background.
    
    public Vector3 cutsceneShipStartPos; //The ships starting position
    public Vector3 cutsceneShipEndPos; //The ships starting position

    public Vector3 cutsceneShipStartRot = new Vector3(0, 0, 45); //The ships starting position
    public float cutsceneLength = 2; //Is in seconds

    private GameObject cutsceneShip; //The reference of the spawned ship
    private SpriteRenderer shipSprite; //The sprite of the background
    // private SpriteRenderer backgroundSprite; //The sprite of the background

    protected override void Start()
    {
        // backgroundSprite = cutsceneBackground.GetComponent<SpriteRenderer>();
        // backgroundSprite.color = new Color(1, 1, 1, 0);

        foreach (SpriteRenderer sprite in cutsceneBackground)
        {
            sprite.color = new Color(1, 1, 1, 0);
        }

        base.Start();
        InitiateTransition();
    }

    protected override void TransitionIn(bool isStartUp)
    {
        base.TransitionIn(isStartUp);
        if (GetType().Equals(typeof(TransitionFadeWithCutscene)) && !lerp.isLerping)
        {
            AssignState(CutsceneIn);
        }
    }

    protected virtual void CutsceneIn(bool isStartUp)
    {
        if (isStartUp)
        {
            lerp.SetValues(0, 1, timeIn);
            return;
        }

        Color alpha = UpdateAlpha(cutsceneBackground[0].color);
        // backgroundSprite.color = UpdateAlpha(backgroundSprite.color);

        foreach (SpriteRenderer sprite in cutsceneBackground)
        {
            sprite.color = alpha;
        }

        if (!lerp.isLerping)
        {
            AssignState(PlayCutscene);
        }
    }

    protected virtual void PlayCutscene(bool isStartUp)
    {
        if (isStartUp)
        {
            lerp.SetValues(0, 1, cutsceneLength);
            if (cutsceneShipPrefab)
            {
                cutsceneShip = Instantiate(cutsceneShipPrefab);
                cutsceneShip.transform.position = cutsceneShipStartPos;
                cutsceneShip.transform.eulerAngles = cutsceneShipStartRot;
                shipSprite = cutsceneShip.GetComponent<SpriteRenderer>();
            }
            return;
        }

        lerp.Update(Time.deltaTime);
        cutsceneShip.transform.position = Vector3.Lerp(cutsceneShipStartPos, cutsceneShipEndPos, lerp.currentValue);
        cutsceneShip.transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(0.1f, 0.1f), lerp.currentValue);

        if (!lerp.isLerping)
        {
            AssignState(CutsceneOut);
        }
    }

    protected virtual void CutsceneOut(bool isStartUp)
    {
        if (isStartUp)
        {
            lerp.SetValues(1, 0, timeOut);
            return;
        }

        // Color alpha = UpdateAlpha(backgroundSprite.color);
        // backgroundSprite.color = alpha;

        Color alpha = UpdateAlpha(cutsceneBackground[0].color);
        foreach(SpriteRenderer sprite in cutsceneBackground)
        {
            sprite.color = alpha;
        }

        shipSprite.color = alpha;

        if (!lerp.isLerping)
        {
            AssignState(WaitingIn);
        }
    }
}
