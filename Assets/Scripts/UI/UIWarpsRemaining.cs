using UnityEngine;

public class UIWarpsRemaining : UICounter
{
    protected MainGameStartUp game;
    private GameObject player;
    float transitionTimer = 5f;

    protected override void Start()
    {
        counterName = " warps to Neptune";
        game = GameObject.FindGameObjectWithTag("StartUp").GetComponent<MainGameStartUp>();
        base.Start();
        player = DoStatic.GetPlayer();
    }

    void Update()
    {
        if (player.activeInHierarchy)
        {
            UIText.enabled = game.warp != 0;
            UpdateUI(game.warp, game.warp + counterName);
        } else {
            UIText.enabled = true;
            UpdateUI(1, "Game Over!");

            if (transitionTimer <= 0f) {
                DoStatic.GetGameController().GetComponent<SceneController>().ChangeScene("MainMenu", "FadeLoss");
            } else {
                transitionTimer -= Time.deltaTime;
            }
        }
    }
}
