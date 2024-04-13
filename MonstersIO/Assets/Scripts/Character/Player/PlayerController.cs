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
    public Slider healthbar;

    private void Start()
    {
        SetUpComponents(this);
        healthbar = GameObject.FindGameObjectWithTag("Healthbar").GetComponent<Slider>();
        SetHealthbar(health.hp);
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FloatingJoystick>();
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

    private void SetHealthbar(int amount)
    {
        healthbar.maxValue = amount;
        healthbar.value = amount;
    }

    private void UpdateHealthbar(int amount)
    {
        healthbar.value = amount;
    }

    public override void CharacterAttack()
    {
        throw new System.NotImplementedException();
    }


    public override void CharacterHealthListener(bool _isdead, int _damage)
    {
        base.CharacterHealthListener(_isdead, _damage);
        UpdateHealthbar(health.hp);
    }

    public override void CharacterMovement()
    {
        Vector2 direction = joystick.Direction;

        rb.velocity = new Vector2(direction.x * movementSpeed, direction.y * movementSpeed);

        if(rb.velocity != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        Flip(direction.x > 0 ? true : false);
    }

}