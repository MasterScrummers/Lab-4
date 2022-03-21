using UnityEngine;

public class UIStage : UICounter
{
    protected StartUpMainGame game;

    protected override void Start()
    {
        counterName = "Stage ";
        game = GameObject.FindGameObjectWithTag("StartUp").GetComponent<StartUpMainGame>();
        base.Start();
    }

    void Update()
    {
        UpdateUI(game.stage, counterName + game.stage);
    }
}
