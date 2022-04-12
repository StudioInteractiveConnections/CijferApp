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

    private State _currentState;
    private StatePatrol patrolState = new StatePatrol();
    private StateFollow followState = new StateFollow();
    private StateArrest arrestState = new StateArrest();

    // Start is called before the first frame update
    void Start()
    {
        pos1 = transform.position;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        //StartCoroutine(FOVCheck());

        _currentState = patrolState;
        Debug.Log(_currentState);
        _currentState.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);

        if (transform.position == pos1)
        {
            SetDirection(pos2);
        }
        else if (transform.position == pos2)
        {
            SetDirection(pos1);
        }

        Move();
        UpdateState();
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    private void SetDirection(Vector3 des)
    {
        destination = des;
        //Debug.Log(destination);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, spd * Time.deltaTime);
    }

    private void UpdateState()
    {
        //Debug.Log(_currentState);
        Debug.Log(this);
        _currentState.Execute(this);
    }

    public void SwitchState(State newState)
    {
        _currentState = newState;
        _currentState.Enter(this);
    }

    private void FOV()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            Vector3 dirToPlayer = (player.transform.position - transform.position).normalized;
        }
        //Debug.Log("FOV");
        /*Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetlayer);

        Debug.Log(rangeCheck.Length);
        if (rangeCheck.Length > 0)
        {
            Debug.Log("rangecheck");
            Transform target = rangeCheck[0].transform;
            Vector2 targetdir = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, targetdir) < angle / 2)
            {
                Debug.Log("angle");
                float disToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, targetdir, disToTarget, obstructionlayer))
                {
                    canSeePlayer = true;
                    Debug.Log("can see player");
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirFromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle02 = DirFromAngle(-transform.eulerAngles.z, angle / 2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

        if (canSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, player.transform.position);
        }
    }

    private Vector2 DirFromAngle(float eulerY, float angleDegrees)
    {
        angleDegrees += eulerY;
        return new Vector2(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
    }
}
