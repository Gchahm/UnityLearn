using System;
using UnityEngine;

public class Timer
{
    private readonly float _speed;
    private float _timer;

    public Timer(float speed)
    {
        _speed = speed;
    }

    public void Tick<T>(Func<T> timerFunc)
    {
        if (_timer < _speed)
            _timer += Time.deltaTime;
        else
        {
            _timer = 0;
            timerFunc();
        }
    }
    
}