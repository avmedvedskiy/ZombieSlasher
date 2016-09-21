using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISkill : MonoBehaviour
{
    public Skill skill;
    public Text countText;

    public void SetSkill(Skill skill)
    {
        if (skill == null)
            return;

        this.skill = skill;
        this.skill.OnUseSkill += OnUseSkill;
    }

    public void OnDisable()
    {
        if(skill != null)
            this.skill.OnUseSkill -= OnUseSkill;
    }

    public void OnUseSkill()
    {
        if (skill == null)
            return;

        Debug.Log("UISkill.OnUseSkill");
        countText.text = skill.GetLeftCount().ToString();
    }
}
