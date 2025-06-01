using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, DisableButton);
    }

    public void DisableButton()
    {
        startButton.SetActive(false);
    }

    public void Execute()
    {
        State.Publish(Condition.START);
    }

    public void Resume()
    {
        Debug.Log("Resume");

    }

    public void OnDisable()
    {
        State.UnSubscribe(Condition.START, DisableButton);
    }

}
