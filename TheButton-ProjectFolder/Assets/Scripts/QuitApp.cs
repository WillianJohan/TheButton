using UnityEngine;

public class QuitApp : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CloseApp();
    }

    public void CloseApp() => Application.Quit();
}
