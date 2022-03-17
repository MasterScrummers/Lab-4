public class UIScore : UICounter
{
    protected override void Start()
    {
        counterName = "Score";
        base.Start();
    }

    void Update()
    {
        UpdateUI(varController.score);
    }
}
