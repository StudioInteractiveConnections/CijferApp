using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private int sightRadius = 5;
    private int arrestRadius = 2;
    private int angle = 90;
    private int angleDirection;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask obstructionLayer;

    [SerializeField] private Rigidbody2D player;

    private Guard guard;

    void Start()
    {
        guard = gameObject.GetComponent<Guard>();
    }

    void Update()
    {
        FOV();
    }

    private void FOV()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < arrestRadius)
        {
            guard.SetArrest(true);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < sightRadius)
        {
            //Vector3 dirToPlayer = (player.transform.position - transform.position).normalized;
        }
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, sightRadius, playerLayer);

        if (rangeCheck.Length > 0)
        {
            Debug.Log(rangeCheck.Length);
            Transform target = rangeCheck[0].transform;
            Vector2 targetdir = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, targetdir) < angle / 2)
            //if (Vector2.Angle(transform.up, targetdir) < angleDirection)
            {
                float disToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, targetdir, disToTarget, obstructionLayer))
                {
                    guard.SetCanSee(true);
                }
                else
                {
                    guard.SetCanSee(false);
                }
            }
            else
            {
                guard.SetCanSee(false);
            }
        }
        else if (guard.GetCanSee())
        {
            guard.SetCanSee(false);
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirFromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle02 = DirFromAngle(-transform.eulerAngles.z, angle / 2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);
        Gizmos.DrawLine(transform.position, player.transform.position);

        if (guard.canSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, player.transform.position);
        }
    }

    private Vector2 DirFromAngle(float eulerY, float angleDegrees)
    {
        angleDegrees += eulerY;
        return new Vector2(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
    }*/
}
