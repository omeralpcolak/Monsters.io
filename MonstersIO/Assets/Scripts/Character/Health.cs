using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Action<bool, int> listener;
    public int hp;
    private Slider healthbar;

    private void Start()
    {
        healthbar = GetComponentInChildren<Slider>();
        UpdateHealthbar(hp);
    }

    public void TakeDamage(int _damage)
    {
        hp -= _damage;
        UpdateHealthbar(hp);
        listener?.Invoke(hp <= 0 ? true : false, _damage);
    }

    private void UpdateHealthbar(int amount)
    {
        healthbar.maxValue = amount;
    }
}
