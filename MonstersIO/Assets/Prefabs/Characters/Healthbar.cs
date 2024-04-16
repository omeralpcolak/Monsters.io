using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public PlayerController player;
    public Vector3 offset;
    private bool canFollow;

    public void Init(PlayerController owner)
    {
        player = owner;
        transform.parent = null;
        SetMaxHealth(player.health.hp);
        UpdateHealthbar(player.health.hp);
        canFollow = true;
    }

    public void SetMaxHealth(int _amount)
    {
        slider.maxValue = _amount;
    }

    public void UpdateHealthbar(int _amount)
    {
        slider.value = _amount;
    }

    private void Update()
    {
        if (canFollow) { transform.position = player.transform.position + offset; }
    }

}
