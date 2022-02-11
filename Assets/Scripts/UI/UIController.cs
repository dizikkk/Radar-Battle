using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;

    private void Awake()
    {
        Timer.OnTimeChanged += ChangeTimer;
    }

    private void ChangeTimer(float timeValue)
    {
        _timer.text = $"Время боя: { Math.Round(timeValue, 2)}";
    }
}