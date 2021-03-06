﻿using UnityEngine;
using System.Collections;
using System;

public class GameController : Singleton<GameController>
{
    public int maxEscapedMonsters = 3;

    protected int m_EscapedMonsters = 0;
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

    protected int m_FriendlyCharacters = 0;
    public int FriendlyCharacters
    {
        get { return m_FriendlyCharacters; }
        protected set { m_FriendlyCharacters = value; }
    }

    public bool isGamePaused = false;
    public bool isGameComplete= false;


    public Action OnMonsterKill;
    public Action OnMonsterEscape;

    public Action OnGameComplete;
    public Action OnGameOver;
    public Action OnGameRestart;
    public Action<bool> OnGamePause;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void KillMonster()
    {
        KilledMonsters++;
        Debug.Log("Kill monster. Count = " + KilledMonsters);
        SafeCall(OnMonsterKill);
        CheckCompleteGame();
    }

    public void CheckCompleteGame()
    {
        int monsterBalance = KilledMonsters + FriendlyCharacters + EscapedMonsters;

        if (LevelController.Instance.leftCount <= 0)
        {
            if (monsterBalance == LevelController.Instance.monsterCount)
            {
                GameComplete();
                return;
            }
        }

        if (LevelController.Instance.isTimeOver)
        {
            int leftMonsters = LevelController.Instance.monsterCount - LevelController.Instance.leftCount;
            if (monsterBalance == leftMonsters)
            {
                GameComplete();
                return;
            }
        }
    }

    public void AddFriednly()
    {
        FriendlyCharacters++;
        Debug.Log("Friendly Characters. Count = " + FriendlyCharacters);
        CheckCompleteGame();
    }

    public void EscapeMonster()
    {
        EscapedMonsters++;
        if (EscapedMonsters == maxEscapedMonsters)
            GameOver();
        Debug.Log("Monster escape. Left monsters  = " + EscapedMonsters);

        SafeCall(OnMonsterEscape);
    }

    public void GameComplete()
    {
        Debug.Log("GameComplete");
        isGameComplete = true;
        UIManager.Instance.GameComplete();
        SafeCall(OnGameComplete);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        isGameComplete = true;
        UIManager.Instance.GameOver();
        SafeCall(OnGameOver);
    }

    public void StartPause()
    {
        SetPause(true);
        SafeCall(OnGamePause, true);
    }

    public void ResetPause()
    {
        SetPause(false);
        SafeCall(OnGamePause, false);
    }

    public void SetPause(bool pause)
    {
        isGamePaused = pause;
    }

    public void Restart()
    {
        EscapedMonsters = 0;
        KilledMonsters = 0;
        FriendlyCharacters = 0;
        isGamePaused = false;
        isGameComplete = false;
        SkillController.Instance.Restart();
        LevelController.Instance.Restart();
        ResetPause();
        SafeCall(OnGameRestart);
    }

    public static void SafeCall(Action a)
    {
        if(a != null)
            a.Invoke();
    }

    public static void SafeCall<T>(Action<T> a,T param)
    {
        if (a != null)
            a.Invoke(param);
    }
}
