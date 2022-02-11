using System;
using UnityEngine;

public class WarriorAttack : MonoBehaviour
{
    public static event Action<Warrior> OnDeath;

    [SerializeField] private float _damage;

    [SerializeField] private float _radiusAttack;

    private Vector3 _heading;

    private float _distance;

    public void Attack(Warrior targetAttack)
    {
        if (targetAttack == null)
            return;

        _heading = targetAttack.transform.position - gameObject.transform.position;

        _distance = _heading.magnitude;

        if (_distance <= _radiusAttack)
        {
            targetAttack.WarriorHealth.ReduceHealth(_damage);
        }
    }
}