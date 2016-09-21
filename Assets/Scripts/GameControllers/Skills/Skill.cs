using UnityEngine;
using System.Collections;
using System;


public class Skill
{
    public int count;
    protected int m_LeftCount;

    public Action OnUseSkill;

    public Skill()
    {
        count = 3;
        m_LeftCount = count;
    }

    public Skill(int count)
    {
        this.count = count;
        m_LeftCount = this.count;
    }

    public int GetLeftCount()
    {
        return m_LeftCount;
    }

    public virtual void Use(BaseUnit unit)
    {
        if (m_LeftCount == 0)
            return;

        m_LeftCount--;

        GameController.SafeCall(OnUseSkill);
    }

    public virtual void Restart()
    {
        m_LeftCount = count;
    }
    
}
