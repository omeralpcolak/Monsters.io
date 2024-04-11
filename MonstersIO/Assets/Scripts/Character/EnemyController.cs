using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterBehaviour
{

    public Transform player;

    private void Start()
    {
        SetUpComponents(this);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        CharacterMovement();
    }

    public override void CharacterAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void CharacterDeath()
    {
        throw new System.NotImplementedException();
    }

    public override void CharacterMovement()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * movementSpeed * Time.fixedDeltaTime);

        Flip(direction.x > 0 ? true : false);
    }
}
