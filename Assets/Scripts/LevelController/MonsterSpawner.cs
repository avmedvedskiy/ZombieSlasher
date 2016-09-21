using UnityEngine;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{
    public float maxOffset = 5f;
    public List<BaseUnit> units = new List<BaseUnit>();

	public void Spawn (int count)
    {
	    for(int i =0; i< count; i++)
        {
            Vector3 randomPosition = Random.insideUnitSphere * maxOffset;
            randomPosition.y = 0f;
            Vector3 monsterPosition = transform.position + randomPosition;

            var monster = Instantiate(units[Random.Range(0, units.Count)]);
            monster.transform.position = monsterPosition;
            monster.moveSpeed += Random.Range(-1f, 2f);
        }
	}
}
