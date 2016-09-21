using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public Dictionary<string, UIWindow> windows = new Dictionary<string, UIWindow>();

	void Awake ()
    {
        DontDestroyOnLoad(gameObject);
        windows = GetComponentsInChildren<UIWindow>(true).ToDictionary(x => x.windowName);
        
#if UNITY_EDITOR
        Debug.Log("Windows count: " + windows.Count);
        foreach(var window in windows)
        {
            Debug.Log(window.Key);
        }
#endif
    }

    public void ToMainMenu()
    {
#if UNITY_EDITOR
        Debug.Log("ToMainMenu");
#endif
        UIManager.Instance.ShowWindow(UIConstants.UIWindowNames.MAIN_MENU);
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        GameController.Instance.Restart();
    }

    public void GameOver()
    {
        ShowWindow(UIConstants.UIWindowNames.FINISH_GAME);
    }

    public void GameComplete()
    {
        ShowWindow(UIConstants.UIWindowNames.GAME_COMPLETE);
    }

    public void ShowWindow(string name)
    {
        var window = GetWindowByName(name);
        if(window)
            window.Show();
    }

    public void HideWindow(string name)
    {
        var window = GetWindowByName(name);
        if(window)
            window.Hide();
    }

    public void ToogleWindow(string name)
    {
        var window = GetWindowByName(name);
        if (window)
            window.Toggle();
    }

    public UIWindow GetWindowByName(string name)
    {
        return windows.ContainsKey(name) ? windows[name] : null;
    }
}
