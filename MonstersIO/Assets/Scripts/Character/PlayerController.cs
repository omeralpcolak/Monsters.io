using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PlayerController : CharacterBehaviour
{

    private FloatingJoystick joystick;
    public List<Skill> skills;
    public List<Transform> spawnPoses;
    //public SpriteRenderer[] renderers;

    private void Start()
    {
        SetUpComponents(this);
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FloatingJoystick>();
        //renderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            skills.ForEach(x => x.Use(this,SetPos(x.spawnPosName)));
        }
    }

    private Transform SetPos(string posName)
    {
        int index = spawnPoses.FindIndex(t => t.name.ToLower() == posName.ToLower());
        return spawnPoses[index];
    }


    private void FixedUpdate()
    {
        CharacterMovement();
    }

    public override void CharacterAttack()
    {
        throw new System.NotImplementedException();
    }


    public override void CharacterHealthListener(bool _isdead, int _damage)
    {
        base.CharacterHealthListener(_isdead, _damage);
    }

    public override void CharacterDeath()
    {
        throw new System.NotImplementedException();
    }

    public override void CharacterMovement()
    {
        Vector2 direction = joystick.Direction;

        rb.velocity = new Vector2(direction.x * 5, direction.y * 5);

        if(rb.velocity != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (direction.x > 0)
        {
            Flip(true);
        }

        if (direction.x < 0)
        {
            Flip(false);
        }
    }

    private void Flip(bool _bool)
    {
        /*foreach(SpriteRenderer renderer in renderers)
        {
            renderer.flipX = _bool ? true : false;
        }*/

        transform.localScale = _bool ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);

    }
}
