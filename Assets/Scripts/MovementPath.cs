using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    /// <summary>
    /// Script is responsible for building a Bézier curve and drawing a route.
    /// </summary>
    #region Fields
    [SerializeField] 
    private Transform[] constructionPoints;
    [SerializeField] 
    private GameObject pointOfWay;
    private Vector2 wayPoint;
    private List<Vector2> wayPointsPosition = new List<Vector2>();
    private List<GameObject> wayPoints = new List<GameObject>();
    #endregion

    #region Properties
    public Transform[] ConstructionPoints
    {
        get { return constructionPoints; }
        set { constructionPoints = value; }
    }
    public GameObject PointOfWay
    {
        get { return pointOfWay; }
        set { pointOfWay = value; }
    }
    public Vector2 WayPoint
    {
        get { return wayPoint; }
        set { wayPoint = value; }
    }
    public List<Vector2> WayPointsPosition
    {
        get { return wayPointsPosition; }
        set { wayPointsPosition = value; }
    }
    public List<GameObject> WayPoints
    {
        get { return wayPoints; }
        set { wayPoints = value; }
    }
    #endregion

    #region Methods
    void Start()
    {
        DrawWay();
        for (int i = 0; i < WayPoints.Count - 1; i++)
        {
            Instantiate(WayPoints[i], WayPointsPosition[i], Quaternion.identity);
        }
    }

    //Drawing a route.
    void DrawWay()
    {
        for(float t = 0; t <= 1; t += 0.01f)
        {
            //Cubic Bezier formula.
            WayPoint = Mathf.Pow(1 - t, 3) * ConstructionPoints[0].position +  
                3 * Mathf.Pow(1 - t, 2) * t * ConstructionPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * ConstructionPoints[2].position +
                Mathf.Pow(t, 3) * ConstructionPoints[3].position;

            WayPoints.Add(PointOfWay);
            WayPointsPosition.Add(WayPoint);
        }       
    }
    #endregion
}
