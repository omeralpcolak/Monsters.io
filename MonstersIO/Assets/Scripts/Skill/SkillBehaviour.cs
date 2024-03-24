using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBehaviour : MonoBehaviour
{
    [SerializeField]protected int damage;

    public virtual void Init(SkillConfig _skillConfig)
    {
        damage = _skillConfig.damage;
    }

    public virtual void Behaviour()
    {

    }

    public virtual void Upgrade()
    {

    }
}
