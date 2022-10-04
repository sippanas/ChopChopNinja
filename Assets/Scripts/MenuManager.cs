using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SceneSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        // IMixedRealitySceneSystem sceneSystem = MixedRealityToolkit.Instance.GetService<IMixedRealitySceneSystem>();
        // await sceneSystem.LoadContent("GameScene", LoadSceneMode.Single);
        StartCoroutine(LoadGameSceneAsync());
        Debug.Log("Trying to load the scene?");
    }

    IEnumerator LoadGameSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameScene");

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
