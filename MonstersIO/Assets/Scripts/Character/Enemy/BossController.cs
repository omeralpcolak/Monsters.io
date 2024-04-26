using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : CharacterBehaviour
{

    public Healthbar healthbar;
    public Transform bossSprite;
    public Transform player;


    public override void CharacterAttack()
    {
        
    }

    public override void CharacterDeath()
    {
        Debug.Log("Boss is dead");
    }

    public override void CharacterMovement()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * movementSpeed * Time.fixedDeltaTime);

        Flip(direction.x > 0 ? true : false, bossSprite);
    }

    public override void CharacterHealthListener(bool _isdead, int _damage)
    {
        base.CharacterHealthListener(_isdead, _damage);
        healthbar.UpdateHealthbar(health.hp);
    }

    void Start()
    {
        SetUpComponents(this);
        healthbar.Init(this);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            playerHealth.TakeDamage(playerHealth.hp);
        }
    }

    void FixedUpdate()
    {
        if (player)
        {
            CharacterMovement();
        }
    }
}
