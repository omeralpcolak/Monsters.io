using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public SkillConfig skillConfig;
    public SkillBehaviour skillBehaviour;

    public virtual void Use(MonoBehaviour _monoBehaviour)
    {
        SkillBehaviour skillIns = Instantiate(skillBehaviour);
        skillIns.Init(this.skillConfig);
    }
}
