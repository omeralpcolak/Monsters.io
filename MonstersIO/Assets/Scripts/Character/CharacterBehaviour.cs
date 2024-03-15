using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : MonoBehaviour
{
    public abstract void CharacterMove();
    public abstract void CharacterAttack();
    public abstract void CharacterDeath();
}
