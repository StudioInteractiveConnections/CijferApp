using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private int radius = 5;
    private int angle = 90;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask obstructionLayer;

    private bool canSeePlayer = false;
    [SerializeField] private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        //player = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
        //Debug.Log("FOV");
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, playerLayer);

        //Debug.Log(rangeCheck.Length);
        if (rangeCheck.Length > 0)
        {
            //Debug.Log("rangecheck");
            Transform target = rangeCheck[0].transform;
            Vector2 targetdir = (target.position - transform.position).normalized;

            //Debug.Log("angle: " + Vector2.Angle(transform.up, targetdir) + "\n" + angle / 2);

            if (Vector2.Angle(transform.up, targetdir) < angle / 2)
            {
                //Debug.Log("angle");
                float disToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, targetdir, disToTarget, obstructionLayer))
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirFromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle02 = DirFromAngle(-transform.eulerAngles.z, angle / 2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, player.transform.position);

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
