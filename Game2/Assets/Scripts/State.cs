using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum Condition
{
    START,
    FINISH,
    RESUME
}
public static class State
{
    private static Action start;
    private static Action finish;
    private static Action resume;

    public static void Subscribe(Condition condition, UnityAction unityAction)
    {
        UnityEvent unityEvent = new UnityEvent();

        unityEvent.AddListener(unityAction);
        switch(condition)
        {
            case Condition.START:
                break;
            case Condition.FINISH:
                break;
            case Condition.RESUME:
                break;
        }
    

    }
    public static void UnSubscribe(Condition condition, UnityAction unityAction)
    {

    }
    public static void Publish(Condition condition)
    {

    }
}
