using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPauseMenu : UIWindow
{
    public Text killedMonsters;
    public Text escapedMonsters;

    public override void Show()
    {
        base.Show();
        GameController.Instance.StartPause();

        if(killedMonsters)
            killedMonsters.text = GameController.Instance.KilledMonsters.ToString();

        if (escapedMonsters)
            escapedMonsters.text = GameController.Instance.EscapedMonsters.ToString();
    }

    public override void Hide()
    {
        base.Hide();
        GameController.Instance.ResetPause();
    }

}
