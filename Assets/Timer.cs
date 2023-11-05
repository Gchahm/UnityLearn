using System;
using UnityEngine;

public class Timer
{
    private readonly float _baseThreshold;
    private float _currentTick;

    public Timer(float baseThreshold)
    {
        _baseThreshold = baseThreshold;
        Modifier = 1;
    }

    public float Modifier { get; set; }

    public void Tick<T>(Func<T> timerFunc)
    {
        if (_currentTick < _baseThreshold / Modifier)
            _currentTick += Time.deltaTime;
        else
        {
            _currentTick = 0;
            timerFunc();
        }
    }
    
}