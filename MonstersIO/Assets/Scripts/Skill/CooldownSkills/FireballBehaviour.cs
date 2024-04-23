using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : SkillBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rb;
    private int speed = 5;

    public override void Init(SkillConfig _skillConfig)
    {
        base.Init(_skillConfig);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;
        Behaviour();
    }

    public override void Behaviour()
    {
        rb.velocity = direction * speed;
    }
}
