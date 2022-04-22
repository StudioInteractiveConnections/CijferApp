using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    private Rigidbody2D rb;
    private float spd = 3;

    public Vector3 pos1;
    public Vector3 pos2;
    private Vector3 destination;

    private int radius = 5;
    [Range(1, 360)] private float angle = 90;
    [SerializeField] private LayerMask targetlayer;
    [SerializeField] private LayerMask obstructionlayer;

    private GameObject player;
    private bool canSeePlayer = false;
    private bool canArrestPlayer = false;

    private StatePatrol patrolState = new StatePatrol();
    //private StateFollow followState = new StateFollow();
    //private StateArrest arrestState = new StateArrest();
    private State _currentState;

    void Start()
    {
        pos1 = transform.position;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        _currentState = patrolState;
        _currentState.Enter(this);
    }

    void Update()
    {
        if (transform.position == pos1)
        {
            SetDirection(pos2);
        }
        else if (transform.position == pos2)
        {
            SetDirection(pos1);
        }

        UpdateState();
    }

    private void SetDirection(Vector3 des)
    {
        destination = des;
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, spd * Time.deltaTime);
    }

    public void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, spd * Time.deltaTime);
    }

    private void UpdateState()
    {
        Debug.Log(_currentState);
        _currentState.Execute(this);
    }

    public void SwitchState(State newState)
    {
        _currentState = newState;
        _currentState.Enter(this);
    }

    public bool GetCanSee()
    {
        return canSeePlayer;
    }

    public bool GetArrest()
    {
        Debug.Log("get arrest is " + canArrestPlayer);
        return canArrestPlayer;
    }

    public void SetCanSee(bool b)
    {
        canSeePlayer = b;
    }

    public void SetArrest(bool b)
    {
        canArrestPlayer = b;
    }
}
