using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalker : MonoBehaviour
{
    GameObject path;
    List<Vector2> wayPoints;
    int wayPointNumber;

    void Start()
    {
        path = GameObject.FindWithTag("MovementPath");
        wayPoints = path.GetComponent<MovementPath>().wayPointsPosition;
    }

    void Update()
    {
        if (wayPointNumber == 100)
            Destroy(gameObject);
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[wayPointNumber], 10f * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoints[wayPointNumber]) == 0)
            wayPointNumber++;
    }
}
