using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

public class SkillController : Singleton<SkillController>
{
    protected Skill m_ActiveSkill;
    
    protected List<Skill> m_Skills = new List<Skill>();

    public BombSkill bombSkill = new BombSkill(3, 3);

    public void Awake()
    {
        m_Skills.Add(bombSkill);
    }

    public void UseActiveSkill(BaseUnit unit)
    {
        if(m_ActiveSkill != null)
        {
            m_ActiveSkill.Use(unit);
            m_ActiveSkill = null;
        }
    }

    public Skill GetActiveSkill()
    {
        return m_ActiveSkill;
    }

    public void ActivateSkill<T>()
    {
        m_ActiveSkill = m_Skills.Where(x => x is T).FirstOrDefault();
    }

    public void ActivateSkill(Skill skill)
    {
        m_ActiveSkill = skill;
    }

    public void ActivateSkill(Type type)
    {
        m_ActiveSkill = m_Skills.Where(x => x.GetType() == type).FirstOrDefault();
    }

    public Skill GetSkill<T>()
    {
        return m_Skills.Where(x => x is T).FirstOrDefault();
    }

    public void Restart()
    {
        foreach (var s in m_Skills)
            s.Restart();
    }

}
