using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricCircleBehaviour : SkillBehaviour
{
    public override void Init(SkillConfig _skillConfig)
    {
        transform.localScale = _skillConfig.size;
    }
}
