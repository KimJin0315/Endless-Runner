using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public void Execute()
    {
        State.Publish(Condition.START);

        AudioManager.Instance.Listener("Enter Button");

        AudioManager.Instance.ScenerySound("Execute");

    }

    public void Resume()
    {
        State.Publish(Condition.RESUME);

    }
}
