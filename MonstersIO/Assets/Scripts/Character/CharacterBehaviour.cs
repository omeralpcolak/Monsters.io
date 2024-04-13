using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;
    protected Health health;
    public CharacterConfig characterConfig;
    public int movementSpeed;

    public GameObject hurtEffect;
    public GameObject deathEffect;


    public abstract void CharacterMovement();
    public abstract void CharacterAttack();

    public void SetUpComponents(CharacterBehaviour _character)
    {
        health = _character.GetComponent<Health>();
        rb = _character.GetComponent<Rigidbody2D>();
        anim = _character.GetComponent<Animator>();

        movementSpeed = _character.characterConfig.movementSpeed;
        health.hp = _character.characterConfig.hp;
        health.listener = CharacterHealthListener;
    }

    protected void Flip(bool _bool)
    {
        float xScale = _bool ? -Mathf.Abs(transform.localScale.x) : Mathf.Abs(transform.localScale.x);
        transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
    }

    public virtual void CharacterHealthListener(bool _isdead, int _damage)
    {
        if (!_isdead)
        {
            Instantiate(hurtEffect, transform);
            Debug.Log(name  + "is taking damage: " + _damage);
        }
        else
        {
            Instantiate(deathEffect, transform);
            Destroy(gameObject);
            Debug.Log(name + " is dead!");
        }
    }

    protected void SelfDestruction()
    {
        health.TakeDamage(health.hp);
    }

}
