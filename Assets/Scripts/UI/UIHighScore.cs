public class UIHighScore : UICounter
{
    protected override void Start()
    {
        counterName = "High Score";
        base.Start();
        UpdateUI(varController.highScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (varController.score > varController.highScore)
        {
            UpdateUI(varController.score);
        }
    }
}
