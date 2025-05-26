using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache
{
    static Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds WaitForSecond(float time)
    {
        WaitForSeconds waitForSeconds;

        if (dictionary.TryGetValue(time , out waitForSeconds) == false)
        {
            dictionary.Add(time, new WaitForSeconds(time));
            waitForSeconds = dictionary[time];
        }    

        return waitForSeconds;
    }

}
