using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    [SerializeField] GameObject walker;
    Vector2 startPosition;
    private float InstantiationTimer;
    bool mouseDown;
    float timeMouseDown;

    void Start()
    {
        startPosition = GameObject.FindWithTag("StartPoint").GetComponent<Transform>().position;
    }

    void Update()
    {
        if (mouseDown)
        {
            SpawnWalkersWithInterval();
        }
    }

    private void SpawnWalkersWithInterval()
    {
        timeMouseDown += Time.deltaTime;
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            Instantiate(walker, startPosition, Quaternion.identity);
            InstantiationTimer = 0.5f;
        }
    }

    public void OnPress()
    {
        Instantiate(walker, startPosition, Quaternion.identity);
        mouseDown = true;
    }

    public void OnRelease()
    {
        mouseDown = false;
        timeMouseDown = 0;
    }
}
