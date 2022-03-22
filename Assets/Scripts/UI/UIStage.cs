using UnityEngine;

public class UIStage : UICounter
{
    protected MainGameStartUp game;

    protected override void Start()
    {
        counterName = "Stage ";
        game = GameObject.FindGameObjectWithTag("StartUp").GetComponent<MainGameStartUp>();
        base.Start();
    }

    void Update()
    {
        UpdateUI(game.stage, counterName + game.stage);
    }
}
