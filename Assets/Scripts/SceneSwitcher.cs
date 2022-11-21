using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadGameScene(int sceneIndex)
    {
        StartCoroutine(LoadGameSceneAsync(sceneIndex));
    }

    IEnumerator LoadGameSceneAsync(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneBuildIndex: sceneIndex);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
