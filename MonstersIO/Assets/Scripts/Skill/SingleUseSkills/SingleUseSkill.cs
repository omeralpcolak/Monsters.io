using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Single Use Skill", menuName ="Skill/SingleUse")]
public class SingleUseSkill : Skill
{
    private bool isCreated = false;
    

    public override void Use(MonoBehaviour _monoBehaviour, Transform spawnPos)
    {
        if(!isCreated)
        {
            SkillBehaviour skillIns = Instantiate(skillBehaviour, spawnPos);
            skillIns.Init(this.skillConfig);
            isCreated = true;
        }
    }

    private void OnEnable()
    {
        isCreated = false;
    }
}
