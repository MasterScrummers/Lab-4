public class UILives : UICanvasImages
{
    void Update()
    {
        UpdateDisplay(varController.lives);

        if (varController.lives <= 0)
        {
            DoStatic.GetPlayer().SetActive(false);
            gameObject.SetActive(false);
            
        }
    }
}
