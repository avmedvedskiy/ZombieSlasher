using UnityEngine;
using System.Collections;

[System.Serializable]
public class BombSkill : Skill
{
    public float radius = 3f;

    public GameObject explosive;

    public BombSkill(int count,float radius):base(count)
    {
        this.count = count;
        this.radius = radius;
    }

    public override void Use(BaseUnit unit)
    {
        if (m_LeftCount == 0)
            return;

        m_LeftCount--;

        GameController.SafeCall(OnUseSkill);

        Debug.Log("BombSkill.Use");
        const int UNIT_LAYER = 8;
        int mask = 1 << UNIT_LAYER;
        var colliders = Physics.OverlapSphere(unit.transform.position, radius, mask);
        foreach(var c in colliders)
        {
            var u = c.GetComponent<BaseUnit>();
            if(u != null && u != unit)
                u.Kill();
        }

        if(explosive)
        {
            var newExplosive = GameObject.Instantiate(explosive);
            newExplosive.transform.position = unit.transform.position;
            GameObject.Destroy(newExplosive, 2f);
        }
    }
}
