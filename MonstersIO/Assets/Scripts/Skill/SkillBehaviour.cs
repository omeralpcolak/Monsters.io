using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBehaviour : MonoBehaviour
{
    [SerializeField]protected int damage;
    [SerializeField]protected int cooldown;

    public void Init(SkillConfig _skillConfig)
    {
        damage = _skillConfig.damage;
        cooldown = _skillConfig.cooldown;
    }

    public virtual void Behaviour()
    {

    }

    public virtual void Upgrade()
    {

    }
}
