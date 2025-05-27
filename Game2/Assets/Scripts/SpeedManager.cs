using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    static SpeedManager instance;

    [SerializeField] float speed = 30.0f;
    [SerializeField] float LimitSpeed = 60.0f;

    public float Speed { get { return speed; } }

    public static SpeedManager Instance {  get { return instance; } }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

    public IEnumerator IncreaseSpeed()
    {   
        while (speed <= LimitSpeed)
        {
            speed = speed + 2.5f;
        }

        
        yield return CoroutineCache.WaitForSecond(5.0f);
    }

}
