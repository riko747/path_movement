using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    [SerializeField] 
    private Transform[] constructionPoints;
    private Vector2 wayPoint;

    void OnDrawGizmos()
    {
        for(float t = 0; t <= 1; t += 0.001f)
        {
            wayPoint = Mathf.Pow(1 - t, 3) * constructionPoints[0].position +  
                3 * Mathf.Pow(1 - t, 2) * t * constructionPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * constructionPoints[2].position +
                Mathf.Pow(t, 3) * constructionPoints[3].position;

            Gizmos.DrawSphere(wayPoint, 0.25f);
        }

        Gizmos.DrawLine(new Vector2(constructionPoints[0].position.x, constructionPoints[0].position.y),
            new Vector2(constructionPoints[1].position.x, constructionPoints[1].position.y));

        Gizmos.DrawLine(new Vector2(constructionPoints[2].position.x, constructionPoints[2].position.y),
            new Vector2(constructionPoints[3].position.x, constructionPoints[3].position.y));
    }
}
