using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricCircleBehaviour : SkillBehaviour
{

    public override void Init(SkillConfig _skillConfig)
    {
        base.Init(_skillConfig);
        transform.localScale = _skillConfig.size;
    }

    public override void OnTriggerWithEnemy(Collider2D other)
    {
        base.OnTriggerWithEnemy(other);
    }
}


