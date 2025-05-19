using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    [SerializeField] GameObject [] obstacles;

    [SerializeField] Transform parentPostion;

    [SerializeField] List<GameObject> obstaclesList;


    void Start()
    {

        for(int i = 0; i < obstacles.Length; i++)
        {
            GameObject clone = Instantiate(obstacles[i], parentPostion);

            clone.gameObject.SetActive(false);

            obstaclesList.Add(clone);
        }


    }

    void Update()
    {
        RandomCreate();
    }

    void RandomCreate()
    {

    }
}
