using UnityEngine;
using System.Collections;

public class LevelController : Singleton<LevelController>
{
    public int monsterCount = 40;
    public int leftCount = 40;
    public float levelDuration = 60f;// level duration in seconds;
    public float leftDuration = 60f;
    
    public bool isTimeOver = false;

    public MonsterSpawner spawner;

    [Space]
    [Header("Spawn Settings")]
    public int maxCount = 5;
    public float minWait = 2f;
    public float maxWait = 6f;


    public void Start()
    {
        leftDuration = levelDuration;
        leftCount = monsterCount;
        Spawn();
    }

    public void Spawn()
    {
        if (isTimeOver)
            return;
        if (leftCount <= 0)
            return;

        if (GameController.Instance.isGamePaused)
            return;


        int spawnCount = Random.Range(1, (leftCount > maxCount)? maxCount : leftCount);
        leftCount -= spawnCount;

        spawner.Spawn(spawnCount);
        Invoke("Spawn", Random.Range(minWait, maxWait));
    }


    public void Update()
    {
        if (isTimeOver)
            return;

        if (GameController.Instance.isGamePaused)
            return;

        leftDuration -= Time.deltaTime;

        if (leftDuration <= 0f)
            TimeIsOver();
    }

    public void TimeIsOver()
    {
        isTimeOver = true;
        Debug.Log("Time is over");
    }

    public void MonsterEnded()
    {
        Debug.Log("Monster ended");
    }

    public void Restart()
    {
        CancelInvoke("Spawn");
        leftCount = monsterCount;
        leftDuration = levelDuration;
        isTimeOver = false;
        Invoke("Spawn", minWait);
    }
}
