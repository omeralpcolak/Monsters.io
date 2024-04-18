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

    public void Spawn(Transform _transform, EnemyBase enemyBase)
    {
        var enemy = GameObject.Instantiate(enemyPrefab,_transform.position,Quaternion.identity);
        enemy.enemyBase = OwnerBase(enemyBase);
        enemy.enemyGroup = OwnerGroup(this);
    }

    private EnemyBase OwnerBase(EnemyBase enemyBase) { return enemyBase; }
    private EnemyGroup OwnerGroup(EnemyGroup enemyGroup) { return enemyGroup; }
}

[System.Serializable]
public class EnemyBase
{
    public List<EnemyGroup> enemyGroups;
    public Transform enemyBasePrefab;
    public int groupIndex;
    public EnemyGroup CurrentEnemyGroup => enemyGroups[groupIndex];
    public int Health => enemyGroups.Sum(x => x.totalCount);

    public void CheckHealth()
    {
        Debug.Log(Health);
        if(Health <= 0)
        {
            //Destory base;
        }
    }

    public IEnumerator Check()
    {
        while (0 < CurrentEnemyGroup.totalCount && GameSceneManager.instance.GameStart)
        {
            CurrentEnemyGroup.Spawn(enemyBasePrefab,this);
            CurrentEnemyGroup.currentCount++;
            yield return new WaitForSeconds(CurrentEnemyGroup.cooldown);

           /*if(CurrentEnemyGroup.currentCount == CurrentEnemyGroup.totalCount)
           {
               CurrentEnemyGroup.currentCount = 0;
               groupIndex = (CurrentEnemyGroup == enemyGroups.Last()) ? 0 : groupIndex + 1;
           }*/
        }
    }
    
}

public class LevelManager : MonoBehaviour
{
    public List<EnemyBase> enemyBases;


    void Start()
    {
        enemyBases.ForEach(x => StartCoroutine(x.Check()));
    }

}
