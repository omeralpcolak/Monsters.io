using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : SkillBehaviour
{
    public float cooldown;
    private Vector2 direction;
    private int speed = 5;

    public override void Init(SkillConfig _skillConfig)
    {
        base.Init(_skillConfig);
        cooldown = _skillConfig.cooldown;
    }

    private void Start()
    {
        transform.parent = null;
        direction = Random.insideUnitCircle.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Update()
    {
        Behaviour();   
    }

    public override void Behaviour()
    {
        Debug.Log("Gidiyorr");
        transform.Translate(direction * Time.fixedDeltaTime * speed);
    }

    public override void OnTriggerWithEnemy(Collider2D other)
    {
        other.GetComponent<Health>().TakeDamage(damage);
        Debug.Log(name + "is triggered with enemy");
        //Destroy(gameObject);
    }


    /*private GameObject FindNearestEnemy()
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
    }*/
}
