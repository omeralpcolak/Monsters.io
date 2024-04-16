using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class EnemyGroup
{
    public EnemyController enemyPrefab;
    public float cooldown;
    public float totalCount;
    public int currentCount;

    public void Spawn(Transform _transform)
    {
        var enemy = GameObject.Instantiate(enemyPrefab,_transform.position,Quaternion.identity);
    }
}

[System.Serializable]
public class EnemyBase
{
    public List<EnemyGroup> enemyGroups;
    public Transform enemyBasePrefab;
    public int groupIndex;
    public EnemyGroup CurrentEnemyGroup => enemyGroups[groupIndex];

    
    public IEnumerator Check()
    {
        while (0 < CurrentEnemyGroup.totalCount && GameSceneManager.instance.GameStart)
        {
           CurrentEnemyGroup.currentCount++;
           CurrentEnemyGroup.Spawn(enemyBasePrefab);
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
