using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMenu : MonoBehaviour
{
    public GameObject planet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            VariableController varController = DoStatic.GetGameController().GetComponent<VariableController>();
            varController.DecrementLife();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneController scn = DoStatic.GetGameController().GetComponent<SceneController>();
            InputController input = scn.GetComponent<InputController>();
            input.ToggleInputLock();
            Instantiate(planet);
            
        }
    }
}
