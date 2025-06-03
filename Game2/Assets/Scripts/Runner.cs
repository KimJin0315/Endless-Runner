using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
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

    [SerializeField] Animator animator;


    [SerializeField] float positionx = 4.0f;

    private void OnEnable()
    {
        State.Subscribe(Condition.FINISH, Die);
        State.Subscribe(Condition.FINISH, Release);

        State.Subscribe(Condition.START, StateTrastion);
        State.Subscribe(Condition.START, InputSystem);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void InputSystem()
    {
        StartCoroutine(Coroutine());
    }
    void Release()
    {
        StopAllCoroutines();
    }

    private void FixedUpdate()
    {
        Move();
    }
    IEnumerator Coroutine()
    {
        while (true)
            {

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (roadLine != RoadLine.LEFT)
                {
                    roadLine--;

                    animator.Play("Left Avoid");
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (roadLine != RoadLine.RIGHT)
                {
                    roadLine++;

                    animator.Play("Right Avoid");
                }
            }

            yield return null;
        }

    }

    void Move()
    {
        rigidbody.position = Vector3.Lerp
        (
             rigidbody.position, 
             new Vector3(positionx * (int)roadLine, 0, 0), 
             SpeedManager.Instance.Speed * Time.deltaTime
        );
    }

    void Die()
    {
        animator.Play("Die");
    }
    public void StateTrastion()
    {
        animator.SetTrigger("Start"); // 트리거 동작시키는 코드
    }

    public void Synchronize()
    {
        animator.speed = SpeedManager.Instance.Speed / SpeedManager.Instance.IntializeSpeed;
        
    }
 
    private void OnTriggerEnter(Collider other)
    {
        Obstacles obstacles = other.GetComponent<Obstacles>();

        if (obstacles != null)
        {
            State.Publish(Condition.FINISH);
        }

    }

    private void OnDisable()
    {
        State.UnSubscribe(Condition.FINISH, Die);
        State.UnSubscribe(Condition.FINISH, Release);

        State.UnSubscribe(Condition.START, StateTrastion);
        State.UnSubscribe(Condition.START, InputSystem);
    }

}
