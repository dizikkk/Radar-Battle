using UnityEngine;
using TMPro;

public class Warrior : MonoBehaviour, IWarrior
{
    [SerializeField] private WarriorController _warriorController;

    [SerializeField] private WarriorMovement _warriorMovement;

    [SerializeField] private WarriorHealth _warriorHealth;

    [SerializeField] private WarriorAttack _warriorAttack;

    public WarriorMovement WarriorMovement => _warriorMovement;

    public WarriorHealth WarriorHealth => _warriorHealth;

    public WarriorAttack WarriorAttack => _warriorAttack;

    private void Start()
    {
        _warriorController.Init(this);
    }

    public void GetEnemy(Warrior enemy)
    {
        if (enemy != null)
        {
            _warriorController.Enemy = enemy;
            _warriorController.StartAttack();
        }
    }
}