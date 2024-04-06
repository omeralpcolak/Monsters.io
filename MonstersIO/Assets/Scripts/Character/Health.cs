using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public Action<bool, int> listener;
    public int hp;

    public void TakeDamage(int _damage)
    {
        hp -= _damage;
        listener?.Invoke(hp <= 0 ? true : false, _damage);
    }
}
