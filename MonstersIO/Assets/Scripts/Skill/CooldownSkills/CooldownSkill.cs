using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Cooldown Skill",menuName ="Skill/CooldownSkill")]
public class CooldownSkill : Skill
{
    private bool isOnCooldown;

    public override void Use(MonoBehaviour _monoBehaviour, Transform spawnPos)
    {
        if (!isOnCooldown)
        {
            base.Use(_monoBehaviour,spawnPos);
            _monoBehaviour.StartCoroutine(HandleCooldown(skillConfig.cooldown));
        }
        
    }

    IEnumerator HandleCooldown(float duration)
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(duration);
        isOnCooldown = false;
    }
}
