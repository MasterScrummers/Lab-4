using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    GameObject startScreen;
    CanvasGroup startCG;
    Text startText;
    
    GameObject instructionsScreen;
    CanvasGroup instructionsCG;
    Text continueText;
    
    bool readyForInput;
    bool readyToStart;

    const float fadeTime = 1.0f;

    SceneController sceneController;
    VariableController varController;

    // Start is called before the first frame update
    void Start()
    {
        readyToStart = false;

        sceneController = DoStatic.GetGameController().GetComponent<SceneController>();
        varController = DoStatic.GetGameController().GetComponent<VariableController>();

        // Reset values
        varController.scoreCheck();
        varController.ResetScore();
        varController.ResetLife();
        varController.ResetBlast();

        // Identify menu parts
        foreach (Transform child in DoStatic.GetChildren(transform)) 
        {
            if (child.gameObject.name == "Start Screen")
            {
                startScreen = child.gameObject;
                startCG = startScreen.GetComponent<CanvasGroup>();
            } else if (child.gameObject.name == "Instructions Screen")
            {
                instructionsScreen = child.gameObject;
                instructionsCG = instructionsScreen.GetComponent<CanvasGroup>();
            }
        }

        foreach (Transform child in DoStatic.GetChildren(startScreen.transform))
        {
            if (child.gameObject.name == "Start Text")
            {
                startText = child.gameObject.GetComponent<Text>();
                break;
            } 
        }

        foreach (Transform child in DoStatic.GetChildren(instructionsScreen.transform))
        {
            if (child.gameObject.name == "Continue Text")
            {
                continueText = child.gameObject.GetComponent<Text>();
                break;
            } 
        }

        readyForInput = true;
        StartCoroutine("FlashText", startText);
    }

    // Update is called once per frame
    void Update()
    {
        if (readyForInput)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StopCoroutine("FlashText");
                if (readyToStart)
                {
                    sceneController.ChangeScene("MainGame");
                } else {
                    StartCoroutine("FadeStartToInstructions");
                }
            }
        }
    }

    IEnumerator FlashText(Text textToFlash)
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            textToFlash.enabled = false;
            yield return new WaitForSeconds(0.15f);          
            textToFlash.enabled = true;

            yield return new WaitForSeconds(0.5f);

            textToFlash.enabled = false;
            yield return new WaitForSeconds(0.15f);
            textToFlash.enabled = true;
        }
    }

    IEnumerator FadeStartToInstructions()
    {
        readyForInput = false;
        startCG.blocksRaycasts = false;
        float startTimer = 0;

        while (startTimer < fadeTime)
        {
            startTimer += Time.deltaTime;
            startCG.alpha = 1 - Mathf.Lerp(0, 1, startTimer/fadeTime);
            yield return null;
        }

        float instructionsTimer = 0;

        yield return new WaitForSeconds(0.2f);

        while (instructionsTimer < fadeTime)
        {
            instructionsTimer += Time.deltaTime;
            instructionsCG.alpha = Mathf.Lerp(0, 1, instructionsTimer/fadeTime);
            yield return null;
        }

        instructionsCG.blocksRaycasts = true;
        readyForInput = true;
        readyToStart = true;

        yield return new WaitForSeconds(3.0f);

        continueText.enabled = true;

        StartCoroutine("FlashText", continueText);

        yield break;
    }
}
