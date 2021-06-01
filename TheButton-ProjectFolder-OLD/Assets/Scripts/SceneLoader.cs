using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void RestartScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
