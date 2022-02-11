using System.Collections;
using UnityEngine;

public abstract class WarriorControllerBase : MonoBehaviour
{
    private IWarrior _warrior;

    public void Init(IWarrior warrior)
    {
        _warrior = warrior;
    }

    public void StartAttack()
    {
        StartCoroutine(ProcessAttack(_warrior.WarriorAttack));
    }

    private void Update()
    {
        ProcessHandling(_warrior.WarriorMovement);
        ProcessHealth(_warrior.WarriorHealth);
    }

    protected abstract void ProcessHandling(WarriorMovement warriorMovement);
    protected abstract void ProcessHealth(WarriorHealth warriorHealth);
    protected abstract IEnumerator ProcessAttack(WarriorAttack warriorAttack);
}