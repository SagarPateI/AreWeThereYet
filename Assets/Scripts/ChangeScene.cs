using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadControlsMenu()
    {
        SceneManager.LoadScene("ControlsScene");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene("StartMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
