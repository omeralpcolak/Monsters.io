using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public CharacterBehaviour character;

    public void Init(CharacterBehaviour owner)
    {
        character = owner;
        SetMaxHealth(character.health.hp);
        UpdateHealthbar(character.health.hp);
    }

    public void SetMaxHealth(int _amount)
    {
        slider.maxValue = _amount;
    }

    public void UpdateHealthbar(int _amount)
    {
        slider.value = _amount;
    }
}
