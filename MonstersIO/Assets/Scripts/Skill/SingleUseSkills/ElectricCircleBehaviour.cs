using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricCircleBehaviour : SkillBehaviour
{
    bool isTouchingToEnemy = false;

    public override void Init(SkillConfig _skillConfig)
    {
        base.Init(_skillConfig);
        transform.localScale = _skillConfig.size;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isTouchingToEnemy = false;
        }
    }

    public override void OnTriggerWithEnemy(Collider2D other)
    {
        isTouchingToEnemy = true;
        StartCoroutine(Damage());


        IEnumerator Damage()
        {
            while (isTouchingToEnemy)
            {
                other.GetComponent<Health>().TakeDamage(damage);
                yield return new WaitForSeconds(1f);
                Debug.Log("damage is applied");
            }
        }
    }
}
