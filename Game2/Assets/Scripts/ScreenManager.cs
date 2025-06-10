using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject timePanel;
    [SerializeField] GameObject resultPanel;
    [SerializeField] GameObject startButton;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, ExecuteInterface);
        State.Subscribe(Condition.FINISH, FinishInterface);
    }
    public void ExecuteInterface()
    {
        startButton.SetActive(false);
    }

    public void FinishInterface()
    {
        timePanel.SetActive(false);
        resultPanel.SetActive(true);
    }

    private void OnDisable()
    {
        State.UnSubscribe(Condition.START, ExecuteInterface);
        State.UnSubscribe(Condition.FINISH, FinishInterface);
    }

}
