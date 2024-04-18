using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterBehaviour
{

    public Transform player;
    [HideInInspector] public EnemyBase enemyBase;

    private void Start()
    {
        SetUpComponents(this);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (player)
        {
            CharacterMovement();
        }
        else
        {
            SelfDestruction();
        }
    }

    public override void CharacterAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void CharacterMovement()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * movementSpeed * Time.fixedDeltaTime);

        Flip(direction.x > 0 ? true : false,this.transform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(10);
            health.TakeDamage(health.hp);
        }
    }
}
