using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIMainMenu : UIWindow
{

    public void StartPlay()
    {
#if UNITY_EDITOR
        Debug.Log("StartPlay");
#endif
        SceneManager.LoadScene("GameScene");
        Hide();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        Debug.Log("ExitGame");
#endif
        Application.Quit();
    }

}
