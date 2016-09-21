using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class UIGameHUD : UIWindow
{
    public GameObject template;

    public Text textTime;
    
    protected List<GameObject> m_Crosses = new List<GameObject>();

    public UISkill bombSkill;

    public override void Show()
    {
        base.Show();
        GameController.Instance.OnMonsterEscape += OnEscapedMonster;
        GameController.Instance.OnGameRestart += OnRestart;

        if (bombSkill)
        {
            bombSkill.SetSkill(SkillController.Instance.GetSkill<BombSkill>());
            bombSkill.OnUseSkill();
        }
    }

    public override void Hide()
    {
        base.Hide();
        GameController.Instance.OnMonsterEscape -= OnEscapedMonster;
        GameController.Instance.OnGameRestart -= OnRestart;
    }

    public void Update()
    {
        if(textTime)
        {
            textTime.text = ((int)LevelController.Instance.leftDuration).ToString();
        }
    }

    public void OnEscapedMonster()
    {
        var newTemplate = Instantiate(template);
        newTemplate.GetComponent<RectTransform>().SetParent(template.transform.parent);
        newTemplate.SetActive(true);
        m_Crosses.Add(newTemplate);
    }

    public void OnRestart()
    {
        for(int i =0;i<m_Crosses.Count;i++)
        {
            var cross = m_Crosses[i];
            Destroy(cross);
        }
        m_Crosses.Clear();
        bombSkill.OnUseSkill();
    }

    public void SetActiveSkill(Type skillType)
    {
        SkillController.Instance.ActivateSkill(skillType);
    }

    public void SetBombActiveSkill()
    {
        var bombSkill = SkillController.Instance.GetSkill<BombSkill>();
        SkillController.Instance.ActivateSkill(bombSkill);
    }
}
