using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour, Collidable
{
    [SerializeField] float speed;

    public void Activate()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        
    }


}
