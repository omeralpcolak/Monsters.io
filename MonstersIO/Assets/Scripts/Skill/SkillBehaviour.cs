using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillBehaviour : MonoBehaviour
{
    [SerializeField]protected int damage;

    public virtual void Init(SkillConfig _skillConfig)
    {
        damage = _skillConfig.damage;
    }

    public virtual void Behaviour()
    {

    }

    public virtual void Upgrade()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnTriggerWithEnemy(other);
        }
    }

    public virtual void OnTriggerWithEnemy(Collider2D other)
    {
        other.GetComponent<Health>().TakeDamage(damage);
    }


}
