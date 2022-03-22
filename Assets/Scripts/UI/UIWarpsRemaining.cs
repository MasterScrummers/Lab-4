using UnityEngine;

public class UIWarpsRemaining : UICounter
{
    protected MainGameStartUp game;

    protected override void Start()
    {
        counterName = " warps to Neptune";
        game = GameObject.FindGameObjectWithTag("StartUp").GetComponent<MainGameStartUp>();
        base.Start();
    }

    void Update()
    {
        UIText.enabled = game.warp != 0;
        UpdateUI(game.warp, game.warp + counterName);
    }
}
