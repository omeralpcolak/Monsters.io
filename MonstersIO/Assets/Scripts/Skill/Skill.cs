using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillConfig
{
    public string title;
    public int damage;
    public int cooldown;
}

[CreateAssetMenu(fileName ="New Skill", menuName ="Skill")]
public class Skill : ScriptableObject
{
    public SkillConfig skillConfig;
    public SkillBehaviour skillBehaviour;

    [HideInInspector]public string title;
    [HideInInspector]public int damage;
    [HideInInspector]public int cooldown;

    public void Use()
    {
        SkillBehaviour skillIns = Instantiate(skillBehaviour);
        skillIns.Init(skillConfig);
    }
}
