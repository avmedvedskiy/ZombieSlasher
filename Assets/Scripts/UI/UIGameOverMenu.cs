using UnityEngine;
using System.Collections;

public class UIGameOverMenu : UIWindow
{

    public void Restart()
    {
        UIManager.Instance.Restart();
        Hide();
    }

    public void ToMainMenu()
    {
        UIManager.Instance.ToMainMenu();
        Hide();
    }
}
