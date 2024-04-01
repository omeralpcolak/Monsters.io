using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public SkillConfig skillConfig;
    public SkillBehaviour skillBehaviour;

    public string spawnPosName;

    public virtual void Use(MonoBehaviour _monoBehaviour, Transform spawnPos)
    {
        
    }
}
