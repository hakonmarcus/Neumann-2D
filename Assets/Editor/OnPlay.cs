using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class LoadSceneOnPressingPlay
{

    [SerializeField]
    public static string oldScene;
    public static int currentLevel;

    static LoadSceneOnPressingPlay()
    {
        EditorApplication.playmodeStateChanged += StateChange;
    }

    static void StateChange()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.playmodeStateChanged -= StateChange;
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
            {
                //We're in playmode, just about to change playmode to Editor
                Debug.Log("Loading original level");
                EditorApplication.OpenScene(oldScene);
            }
            else
            {
                //We're in playmode, right after having pressed Play
                oldScene = EditorApplication.currentScene;
                currentLevel = SceneManager.GetActiveScene().buildIndex;
                Debug.Log("Loading first level");
                SceneManager.LoadScene(0);
            }
        }
    }
}
