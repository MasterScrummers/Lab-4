using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    Transform[] canvasChildren;
    Text startText;

    bool startingGame;

    // Start is called before the first frame update
    void Start()
    {
        startingGame = false;

        // Identify menu parts
        canvasChildren = DoStatic.GetChildren(transform);
        foreach (Transform child in canvasChildren) 
        {
            if (child.gameObject.name == "Start Text")
            {
                startText = child.gameObject.GetComponent<Text>();
                
                //remove break if looking for more objects
                break;
            }
        }

        StartCoroutine("FlashStartText");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FlashStartText()
    {
        while (!startingGame)
        {
            yield return new WaitForSeconds(3);

            startText.enabled = false;
            yield return new WaitForSeconds(0.15f);          
            startText.enabled = true;

            yield return new WaitForSeconds(0.5f);

            startText.enabled = false;
            yield return new WaitForSeconds(0.15f);
            startText.enabled = true;
        }
        yield break;
    }
}
