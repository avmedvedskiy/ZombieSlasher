using UnityEngine;
using System.Collections;

public class SimpleUnit : BaseUnit
{

    public override void Kill()
    {
        base.Kill();

        GameController.Instance.KillMonster();
    }

    public override void Escape()
    {
        base.Escape();
        GameController.Instance.EscapeMonster();
    }
}
