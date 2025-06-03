using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : Singleton<SpeedManager>
{

    [SerializeField] float speed = 30.0f;
    [SerializeField] float LimitSpeed = 60.0f;

    [SerializeField] float initializeSpeed;

    public float Speed { get { return speed; } }

    public float IntializeSpeed { get { return initializeSpeed; } }

    private void OnEnable()
    {
        initializeSpeed = speed;

        State.Subscribe(Condition.FINISH, Release);
        State.Subscribe(Condition.START, Execute);
    }

    private void Execute()
    {
        StartCoroutine(Increase());
    }

    void Release()
    {
        StopAllCoroutines();
    }

    IEnumerator Increase()
    {
        
        while (speed < LimitSpeed)
        {
            yield return CoroutineCache.WaitForSecond(0.633f);

            speed = speed + 0.5f;
        }

    }

    private void OnDisable()
    {
        State.UnSubscribe(Condition.FINISH, Release);
        State.UnSubscribe(Condition.START, Execute);
    }

}
