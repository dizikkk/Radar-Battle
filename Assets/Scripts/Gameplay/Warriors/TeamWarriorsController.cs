using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TeamWarriorsController : MonoBehaviour
{
    public static event Action<TeamWarriorsController> OnTeamDeath;

    [SerializeField] private List<Warrior> _warriors;

    public Warrior Enemy { get; set; }

    public List<Warrior> Warriors { get => _warriors; }

    private void Awake()
    {
        GetWarriors();
    }

    private void Start()
    {
        StartCoroutine(GetEnemy());
    }

    private void Update()
    {
        if (!CheckLiveWarriorsInTeam())
        {
            OnTeamDeath?.Invoke(this);
            Destroy(gameObject);
        }
    }

    private void GetWarriors()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var warrior = gameObject.transform.GetChild(i).GetComponent<Warrior>();

            if (warrior != null)
                _warriors.Add(warrior);
        }
    }

    private IEnumerator GetEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            foreach (var warrior in _warriors)
            {
                if (warrior != null)
                    warrior.GetEnemy(Enemy);
            }
        }
    }

    private bool CheckLiveWarriorsInTeam()
    {
        _warriors.RemoveAll(x => x == null);

        if (_warriors.Count > 0)
            return true;

        return false;
    }
}