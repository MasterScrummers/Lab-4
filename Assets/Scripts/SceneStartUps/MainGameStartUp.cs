using System.Collections;
using UnityEngine;

public class MainGameStartUp : MonoBehaviour
{
    private AudioController audioPlayer;
    private VariableController variableController;
    public float stage1Length = 60; //In seconds
    public float stage2Length = 120; //In seconds
    public float stage3Length = 180; //In seconds
    public float warpDisplayLength = 3; //Inseconds
    public int stage { get; private set; } = 0;
    public int warp { get; private set; } = 0;

    private float stageTimer;
    private float warpTimer;

    void Start()
    {
        audioPlayer = DoStatic.GetGameController().GetComponent<AudioController>();
        variableController = audioPlayer.GetComponent<VariableController>();
        updateStage();
    }

    void Update()
    {
        stageTimer -= Time.deltaTime;
        if (stage < 3 && stageTimer < 0)
        {
            updateStage();
        }
        warp = (warpTimer -= Time.deltaTime) > 0 ? 4 - stage : 0;
    }

    private void updateStage()
    {
        audioPlayer.PlayMusic("Stage" + ++stage);
        variableController.ChangeBlast(1);
        warpTimer = 3;
        switch(stage)
        {
            case 1:
                stageTimer = stage1Length;
                return;

            case 2:;
                stageTimer = stage2Length;
                return;

            case 3:
                stageTimer = stage3Length;
                return;
        }
    }
}
