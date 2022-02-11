using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static event Action OnBattleEnd;

    [SerializeField] private List<TeamWarriorsController> _teamsWarriors;

    private void Awake()
    {
        TeamWarriorsController.OnTeamDeath += RemoveTeam;
    }

    private void Start()
    {
        if (CheckTeamsCount())
            StartCoroutine(FindEnemy());
    }

    private IEnumerator FindEnemy()
    {
        while (_teamsWarriors.Count > 1)
        {
            List<Warrior> enemyWarriors = new List<Warrior>();

            yield return new WaitForSeconds(1f);

            if (_teamsWarriors.Count > 1)
            {
                for (int i = 0; i < _teamsWarriors.Count; i++)
                {
                    enemyWarriors.Add(_teamsWarriors[i].Warriors[0]);
                }

                enemyWarriors.Reverse();

                for (int i = 0; i < _teamsWarriors.Count; i++)
                {
                    _teamsWarriors[i].Enemy = enemyWarriors[i];
                }
            }
            else
                OnBattleEnd?.Invoke();
        }
    }

    private void RemoveTeam(TeamWarriorsController teamWarrior)
    {
        _teamsWarriors.Remove(teamWarrior);
    }

    private bool CheckTeamsCount()
    {
        if (_teamsWarriors.Count > 1)
            return true;

        return false;
    }
}