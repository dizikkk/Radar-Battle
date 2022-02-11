using System.Collections;
using System;
using UnityEngine;

public class WarriorController : WarriorControllerBase
{
    public static event Action<float> OnHealthChanged;

    public Warrior Enemy { get; set; }

    protected override IEnumerator ProcessAttack(WarriorAttack warriorAttack)
    {
        if (Enemy != null)
        {
            yield return new WaitForSeconds(1f);
            warriorAttack.Attack(Enemy);
        }
    }

    protected override void ProcessHandling(WarriorMovement warriorMovement)
    {
        if (Enemy != null)
            warriorMovement.Move(Enemy.transform.position);
    }

    protected override void ProcessHealth(WarriorHealth warriorHealth)
    {
        OnHealthChanged?.Invoke(warriorHealth.Health);
    }
}