using UnityEngine;

public class UIWarpsRemaining : UICounter
{
    protected StartUpMainGame game;

    protected override void Start()
    {
        counterName = " warps to Neptune";
        game = GameObject.FindGameObjectWithTag("StartUp").GetComponent<StartUpMainGame>();
        base.Start();
    }

    void Update()
    {
        UIText.enabled = game.warp != 0;
        UpdateUI(game.warp, game.warp + counterName);
    }
}
