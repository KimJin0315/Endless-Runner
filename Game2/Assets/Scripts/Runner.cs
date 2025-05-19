using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}
public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] Rigidbody rigidbody;

    [SerializeField] float positionx = 4.0f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        keyboard();
    }

    private void FixedUpdate()
    {
        Move();
    }
    void keyboard()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != RoadLine.LEFT)
            {
                roadLine--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RoadLine.RIGHT)
            {
                roadLine++;
            }
        }


    }

    void Move()
    {
        rigidbody.position = new Vector3(positionx * (int)roadLine, 0, 0);
    }

}
