using System;
using UnityEngine;

public class WarriorHealth : MonoBehaviour
{
    [SerializeField] private float _health;

    public float Health => _health;

    public void ReduceHealth(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Death();
    }

    public float GetCurrentHealth()
    {
        return _health;
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}