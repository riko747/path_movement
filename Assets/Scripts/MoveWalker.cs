using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalker : MonoBehaviour
{
    /// <summary>
    /// Circle movement logic.
    /// </summary>

    #region Fields
    //Reference to script MovementPath.
    private GameObject path;
    private List<Vector2> wayPoints;
    //The number of the next point in the list to which the circle goes.
    private int wayPointNumber;

    private const int endOfTheList = 101;
    private const float movementSpeed = 10f;
    #endregion

    #region Properties
    public GameObject Path
    {
        get { return path; }
        set { path = value; }
    }

    public List<Vector2> WayPoints
    {
        get { return wayPoints; }
        set { wayPoints = value; }
    }

    public int WayPointNumber
    {
        get { return wayPointNumber; }
        set { wayPointNumber = value; }
    }
    #endregion

    #region Methods
    void Start()
    {
        Path = GameObject.FindWithTag("MovementPath");
        WayPoints = Path.GetComponent<MovementPath>().WayPointsPosition;
    }

    void Update()
    {
        bool walkerOnTheFinish = WayPointNumber == endOfTheList;

        if (walkerOnTheFinish)
        {
            Destroy(gameObject);
        }
        else
        {
            MoveToNextPoint();
        }
    }

    //The method is responsible for moving between points.
    void MoveToNextPoint()
    {
        bool walkerOnThePoint = Vector2.Distance(transform.position, WayPoints[WayPointNumber]) == 0;

        transform.position = Vector2.MoveTowards(transform.position, WayPoints[WayPointNumber], movementSpeed * Time.deltaTime);
        if (walkerOnThePoint)
        {
            WayPointNumber++;
        }
    }
    #endregion
}
