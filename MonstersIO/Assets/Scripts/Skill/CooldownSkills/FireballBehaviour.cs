using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : SkillBehaviour
{
    public float cooldown;
    private Vector2 targetPos;

    public override void Init(SkillConfig _skillConfig)
    {
        base.Init(_skillConfig);
        cooldown = _skillConfig.cooldown;
    }

    private void Start()
    {
        targetPos = FindNearestEnemy().position;
    }

    private void FixedUpdate()
    {
        
    }


    private Transform FindNearestEnemy()
    {
        Vector2 currentPos = transform.position;
        GameObject closestEnemy = null;
        float minDistance = Mathf.Infinity;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(enemy.transform.position, currentPos);

            if(distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }


        return closestEnemy.transform;

    }
}
