using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private string currentScene; //The current scene's name
    private AudioController audioController; //To play correct music on different scene.

    private Dictionary<string, float[]> transitionTimes; //The transition times when changing scenes.
    private TransitionBase currentTransition; //The current transition that is happening.
    private bool isTransitioning; //A check to know when the scene is transitioning.

    void Start()
    {
        currentScene = DoStatic.GetSceneName();
        audioController = GetComponent<AudioController>();
        
        DoSceneStartUp();

        transitionTimes = new Dictionary<string, float[]>();
        transitionTimes.Add("Fade", new float[] { 1, 1 });//[0] is timeIn, [1] is timeOut
    }

    private void DoSceneStartUp()
    {
        switch(currentScene)
        {
            case "MainGame":
                return;
        }
    }

    /// <summary>
    /// Should only be called from a TransitionBase class.
    /// </summary>
    /// <param name="transition">Should be the current transition.</param>
    /// <returns>A float of the times.</returns>
    public float[] GetTransitionTimes(TransitionBase transition)
    {
        currentTransition = transition;
        string transitionName = transition.transitionName;
        return transitionTimes.ContainsKey(transitionName) ? transitionTimes[transitionName] : new float[] { 1, 1 };
    }

    /// <summary>
    /// Changes the scene accordingly.
    /// </summary>
    /// <param name="sceneName">The new scene to load.</param>
    public void ChangeScene(string sceneName)
    {
        if (!isTransitioning)
        {
            isTransitioning = true;
            StartCoroutine(Transition("Fade", sceneName));
        }
    }

    private IEnumerator Transition(string transitionName, string newSceneName)
    {
        DoStatic.LoadScene(transitionName);
        yield return StartCoroutine(Wait("LoadingTransition"));
        currentTransition.InitiateTransition();
        yield return StartCoroutine(Wait("TransitionSlowIn"));

        DoStatic.UnloadScene(currentScene);
        DoStatic.LoadScene(newSceneName);
        currentScene = newSceneName;
        DoSceneStartUp();

        currentTransition.startFinishingUp = true;
        yield return StartCoroutine(Wait("TransitionSlowOut"));
        DoStatic.UnloadScene(transitionName);
        yield return StartCoroutine(Wait("UnloadingTransition"));
        isTransitioning = false;
    }

    private bool WaitCheck(string reason)
    {
        switch (reason)
        {
            case "LoadingTransition":
                return !currentTransition;

            case "TransitionSlowIn":
                return !currentTransition.startLoading;

            case "TransitionSlowOut":
                return currentTransition.startFinishingUp;

            case "UnloadingTransition":
                return currentTransition;
        }
        return true;
    }

    private IEnumerator Wait(string reason)
    {
        yield return new WaitForEndOfFrame();
        while (WaitCheck(reason))
        {
            yield return new WaitForEndOfFrame();
        }
    }
}
