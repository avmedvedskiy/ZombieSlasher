using UnityEngine;
using System.Collections;

public class FriendlyUnit : BaseUnit
{
    public override void Kill()
    {
        GameController.Instance.GameOver();
    }

    public override void Escape()
    {
        base.Escape();
    }
}
