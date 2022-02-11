using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static event Action<float> OnTimeChanged;

    float time = 0f;

    private void Awake()
    {
        BattleController.OnBattleEnd += StopTimer;
    }

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    private void StopTimer()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartTimer()
    {
        while (true)
        {
            yield return null;
            time += Time.deltaTime;
            OnTimeChanged?.Invoke(time);
        }
    }
}