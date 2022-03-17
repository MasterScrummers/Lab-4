using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoStatic
{
    /// <summary>
    /// Get the name of the current scene.
    /// </summary>
    /// <returns>A string of the current scene.</returns>
    public static string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// Loads the scene (by string).
    /// </summary>
    /// <param name="sceneName">The scene name to load into.</param>
    /// <param name="asAdditive">Adds the loaded scene on top of current scene.</param>
    public static void LoadScene(string sceneName, bool asAdditive = true)
    {
        SceneManager.LoadScene(sceneName, asAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single);
    }

    /// <summary>
    /// Loads the scene (by index).
    /// </summary>
    /// <param name="index">Scene to load index.</param>
    /// <param name="asAdditive">Adds the loaded scene on top of current scene.</param>
    public static void LoadScene(int index, bool asAdditive = true)
    {
        LoadScene(SceneManager.GetSceneByBuildIndex(index).name);
    }

    /// <summary>
    /// Unload a given scene (by string).
    /// </summary>
    /// <param name="sceneName">The scene to unload.</param>
    /// <returns>An AsyncOperation to know when the scene has fully unloaded.</returns>
    public static AsyncOperation UnloadScene(string sceneName)
    {
        return SceneManager.UnloadSceneAsync(sceneName);
    }

    /// <summary>
    /// Converts the 0-255 rgb values to a float between 0 - 1.
    /// This is needed for the Color.
    /// </summary>
    /// <param name="r">Red</param>
    /// <param name="g">Green</param>
    /// <param name="b">Blue</param>
    /// <param name="a">Alpha, defaults to 1</param>
    /// <returns>Returns the correct colour.</returns>
    public static Color RGBConverter(int r, int g, int b, int a = 255)
    {
        return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }

    /// <summary>
    /// Get a random colour.
    /// </summary>
    /// <returns>A random colour.</returns>
    public static Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }

    /// <summary>
    /// Get a random bool.
    /// </summary>
    /// <param name="successRate">The successRate. Defaults to 50%. Should be between 0 to 1</param>
    /// <returns>A random bool.</returns>
    public static bool RandomBool(float successRate = 0.5f)
    {
        return Random.value > 1 - successRate;
    }

    /// <summary>
    /// Get all the children of a GameObject.
    /// </summary>
    /// <param name="transform">The transform of the GameObject with children.</param>
    /// <returns>Returns an array of all the children of the given GameObject.</returns>
    public static Transform[] GetChildren(Transform transform)
    {
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i));
        }
        return children.ToArray();
    }

    private static GameObject GetObject(string tag)
    {
        return GameObject.FindGameObjectWithTag(tag);
    }

    /// <summary>
    /// Finds the GameObject with the tag "GameController".
    /// There should only be one!
    /// </summary>
    /// <returns>The GameController GameObject</returns>
    public static GameObject GetGameController()
    {
        return GetObject("GameController");
    }

    /// <summary>
    /// Finds the GameObject with the tag "Player".
    /// There should only be one!
    /// </summary>
    /// <returns>The Player GameObject</returns>
    public static GameObject GetPlayer()
    {
        return GetObject("Player");
    }
}
