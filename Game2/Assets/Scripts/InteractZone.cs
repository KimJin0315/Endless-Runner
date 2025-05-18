using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Collidable collidable = other.GetComponent<Collidable>();     
        
        if(collidable != null)
        {
            collidable.Activate();
        }
    }
}
