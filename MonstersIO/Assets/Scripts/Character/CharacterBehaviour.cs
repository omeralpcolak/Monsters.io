using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;
    public Health health;
    public CharacterConfig characterConfig;
    public int movementSpeed;

    public GameObject hurtEffect;
    public GameObject deathEffect;


    public abstract void CharacterMovement();
    public abstract void CharacterAttack();
    public abstract void CharacterDeath();

    public void SetUpComponents(CharacterBehaviour _character)
    {
        health = _character.GetComponent<Health>();
        rb = _character.GetComponent<Rigidbody2D>();
        //anim = (characterConfig.type == CharacterType.PLAYER) ? GetComponentInChildren<Animator>() : _character.GetComponent<Animator>();
        anim = GetComponentInChildren<Animator>();
        movementSpeed = _character.characterConfig.movementSpeed;
        health.hp = _character.characterConfig.hp;
        health.listener = CharacterHealthListener;
    }

    protected void Flip(bool _bool,Transform _transform)
    {
        float xScale = _bool ? -Mathf.Abs(_transform.localScale.x) : Mathf.Abs(_transform.localScale.x);
        _transform.localScale = new Vector3(xScale, _transform.localScale.y, _transform.localScale.z);
    }

    public virtual void CharacterHealthListener(bool _isdead, int _damage)
    {
        if (!_isdead)
        {
            Instantiate(hurtEffect, transform);
            
        }
        else
        {
            CharacterDeath();
        }
    }

    protected void SelfDestruction()
    {
        health.TakeDamage(health.hp);
    }

}
