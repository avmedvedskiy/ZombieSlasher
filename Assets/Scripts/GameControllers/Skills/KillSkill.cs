using UnityEngine;
using System.Collections;

public class KillSkill : Skill
{
    public override void Use(BaseUnit unit)
    {
        Debug.Log("KillSkill.Use");
        unit.Kill();
    }
}
