using UnityEngine;

public class StartUpMainGame : MonoBehaviour
{
    void Start()
    {
        DoStatic.GetGameController().GetComponent<AudioController>().PlayMusic("Stage1");
    }
}
