using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    /// <summary>
    /// Button behaviour.
    /// </summary>

    #region Fields
    //Green circle that moves along a trajectory.
    [SerializeField] 
    private GameObject walker;

    //Green circle spawn position.
    private Vector2 startPosition;

    //Period of spawning of a green circle.
    private float instantiationTimer;
    //A timer that checks how long the button has been pressed. 
    private float timeMouseDown;
    //Button state (clicked/not clicked).
    private bool mouseDown;
    #endregion

    #region Properties
    public GameObject Walker
    {
        get { return walker; }
        set { walker = value; }
    }

    public Vector2 StartPosition
    {
        get { return startPosition; }
        set { startPosition = value; }
    }

    public float InstantiationTimer
    {
        get { return instantiationTimer; }
        set { instantiationTimer = value; }
    }
    public float TimeMouseDown
    {
        get { return timeMouseDown; }
        set { timeMouseDown = value; }
    }
    public bool MouseDown
    {
        get { return mouseDown; }
        set { mouseDown = value; }
    }
    #endregion

    #region Methods
    void Start()
    {
        StartPosition = GameObject.FindWithTag("StartPoint").GetComponent<Transform>().position;
    }

    void Update()
    {
        if (MouseDown)
        {
            SpawnWalkersWithInterval();
        }
    }

    private void SpawnWalkersWithInterval()
    {
        TimeMouseDown += Time.deltaTime;
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            Instantiate(Walker, StartPosition, Quaternion.identity);
            InstantiationTimer = 0.5f;
        }
    }
    public void OnPress()
    {
        Instantiate(Walker, StartPosition, Quaternion.identity);
        MouseDown = true;
    }

    public void OnRelease()
    {
        MouseDown = false;
        TimeMouseDown = 0;
    }
    #endregion
}
