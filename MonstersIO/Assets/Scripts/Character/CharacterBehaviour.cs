using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;


    public void SetUpComponents(CharacterBehaviour _character)
    {
        rb = _character.GetComponent<Rigidbody2D>();
        anim = _character.GetComponent<Animator>();
    }

    public abstract void CharacterMovement();
    public abstract void CharacterAttack();
    public abstract void CharacterDeath();
}
