using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private int radius = 5;
    private int angle = 90;

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
        if (Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            Vector3 dirToPlayer = (player.transform.position - transform.position).normalized;
        }
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, playerLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 targetdir = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, targetdir) < angle / 2)
            {
                float disToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, targetdir, disToTarget, obstructionLayer))
                {
                    guard.canSeePlayer = true;
                }
                else
                {
                    guard.canSeePlayer = false;
                }
            }
            else
            {
                guard.canSeePlayer = false;
            }
        }
        else if (guard.canSeePlayer)
        {
            guard.canSeePlayer = false;
        }
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
    }
}
