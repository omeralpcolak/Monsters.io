using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class EnemyGroup
{
    public EnemyController enemyPrefab;
    public float cooldown;
    public int totalCount;
    public int currentCount;
    [HideInInspector]public int health;


    public void SetHealth()
    {
        health = totalCount;
    }

    public void Spawn(Transform _transform, EnemyBase enemyBase)
    {
        var enemy = GameObject.Instantiate(enemyPrefab,_transform.position,Quaternion.identity);
        enemy.enemyBase = enemyBase;
        enemy.enemyGroup = this;
    }
}

[System.Serializable]
public class EnemyBase
{
    public List<EnemyGroup> enemyGroups;
    public Transform enemyBasePrefab;
    public GameObject destroyEffect;
    public int groupIndex;
    public EnemyGroup CurrentEnemyGroup => enemyGroups[groupIndex];
    public int Health => enemyGroups.Sum(x => x.health);

    public void CheckHealth()
    {
        if(Health <= 0)
        {
            GameObject.Instantiate(destroyEffect, enemyBasePrefab.position, Quaternion.identity);
            GameObject.Destroy(enemyBasePrefab.gameObject);
        }
    }

    public void SetHealthOfTheGroups()
    {
        enemyGroups.ForEach(x => x.SetHealth());
    }

    public IEnumerator Check()
    {

        while (CurrentEnemyGroup.currentCount <= CurrentEnemyGroup.totalCount && GameSceneManager.instance.GameStart)
        {
            CurrentEnemyGroup.Spawn(enemyBasePrefab,this);
            CurrentEnemyGroup.currentCount++;
            yield return new WaitForSeconds(CurrentEnemyGroup.cooldown);

           if(CurrentEnemyGroup.currentCount == CurrentEnemyGroup.totalCount)
           {
                CurrentEnemyGroup.currentCount = 0;
                CurrentEnemyGroup.totalCount = 0;

                if(CurrentEnemyGroup == enemyGroups.Last())
                {
                    break;
                }
                else
                {
                    groupIndex++;
                }
           }
        }
    }
    
}

public class LevelManager : MonoBehaviour
{
    public List<EnemyBase> enemyBases;


    void Start()
    {
        enemyBases.ForEach(x => x.SetHealthOfTheGroups());
        enemyBases.ForEach(x => StartCoroutine(x.Check()));
    }

}
