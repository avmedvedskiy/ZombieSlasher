using UnityEngine;
using System.Collections;

public class FriendlyUnit : BaseUnit
{
    public override void Start()
    {
        base.Start();
        GameController.Instance.AddFriednly();
    }

    public override void Kill()
    {
        GameController.Instance.GameOver();
    }

    public override void Escape()
    {
        base.Escape();
    }
}
