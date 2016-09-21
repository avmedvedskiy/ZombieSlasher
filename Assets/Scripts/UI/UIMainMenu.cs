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
        UIManager.Instance.ShowWindow(UIConstants.UIWindowNames.GAME_HUD);
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
