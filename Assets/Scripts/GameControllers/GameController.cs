using UnityEngine;
using System.Collections;
using System;

public class GameController : Singleton<GameController>
{
    protected int m_EscapedMonsters = 3;
    public int EscapedMonsters
    {
        get { return m_EscapedMonsters; }
        protected set { m_EscapedMonsters = value; }
    }
    protected int m_KilledMonsters = 0;
    public int KilledMonsters
    {
        get { return m_KilledMonsters; }
        protected set { m_KilledMonsters = value; }
    }

    public Action OnMonsterKill;
    public Action OnMonsterEscape;

    public Action OnGameComplete;
    public Action OnGameOver;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void KillMonster()
    {
        KilledMonsters++;
        Debug.Log("Kill monster. Count = " + KilledMonsters);
        SafeCall(OnMonsterKill);
    }

    public void EscapeMonster()
    {
        EscapedMonsters--;
        if (EscapedMonsters == 0)
            GameOver();
        Debug.Log("Monster escape. Left monsters  = " + EscapedMonsters);

        SafeCall(OnMonsterEscape);
    }

    public void GameComplete()
    {
        Debug.Log("GameComplete");
        SafeCall(OnGameComplete);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        UIManager.Instance.GameOver();
        SafeCall(OnGameOver);
    }

    public static void SafeCall(Action a)
    {
        if(a != null)
            a.Invoke();
    }
}
