using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameComplete : UIWindow
{
    public Text killedMonsters;
    public Text escapedMonsters;

    public override void Show()
    {
        base.Show();
        killedMonsters.text = GameController.Instance.KilledMonsters.ToString();
        escapedMonsters.text = GameController.Instance.EscapedMonsters.ToString();
    }

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
