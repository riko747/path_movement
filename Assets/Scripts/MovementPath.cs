using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    [SerializeField] Transform[] constructionPoints;
    [SerializeField] GameObject pointOfWay;
    private Vector2 wayPoint;

    public List<Vector2> wayPointsPosition = new List<Vector2>();
    List<GameObject> wayPoints = new List<GameObject>();

    void Start()
    {
        DrawWay();
        for (int i = 0; i < wayPoints.Count - 1; i++)
        {
            Instantiate(wayPoints[i], wayPointsPosition[i], Quaternion.identity);
        }
    }

    void DrawWay()
    {
        for(float t = 0; t <= 1; t += 0.01f)
        {
            wayPoint = Mathf.Pow(1 - t, 3) * constructionPoints[0].position +  
                3 * Mathf.Pow(1 - t, 2) * t * constructionPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * constructionPoints[2].position +
                Mathf.Pow(t, 3) * constructionPoints[3].position;

            wayPoints.Add(pointOfWay);
            wayPointsPosition.Add(wayPoint);
        }       
    }
}
