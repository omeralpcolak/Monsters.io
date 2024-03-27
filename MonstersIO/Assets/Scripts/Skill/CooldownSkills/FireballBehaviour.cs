using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : SkillBehaviour
{
    public float cooldown;
    private Transform target;
    private int speed = 5;

    public override void Init(SkillConfig _skillConfig)
    {
        base.Init(_skillConfig);
        cooldown = _skillConfig.cooldown;
    }

    private void Start()
    {
       target = FindNearestEnemy().transform;
    }

    private void FixedUpdate()
    {
        Behaviour();
    }


    public override void Behaviour()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * speed);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            return;
        }
    }

    public override void OnTriggerWithEnemy()
    {
        //Instantiate some effect etc..
        Debug.Log(name + "is triggered with enemy");
        Destroy(gameObject);
    }


    private GameObject FindNearestEnemy()
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
        return closestEnemy;
    }
}
