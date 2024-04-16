using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public PlayerController player;
    public Vector3 offset;

    public void Init(PlayerController owner)
    {
        owner = player;
        transform.parent = null;
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
