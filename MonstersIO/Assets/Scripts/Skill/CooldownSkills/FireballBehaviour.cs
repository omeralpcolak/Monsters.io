using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : SkillBehaviour
{
    public float cooldown;

    public override void Init(SkillConfig _skillConfig)
    {
        base.Init(_skillConfig);
        cooldown = _skillConfig.cooldown;
    }
}
