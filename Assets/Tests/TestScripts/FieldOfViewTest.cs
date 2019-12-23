using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewTest : MonoBehaviour
{

    private float viewRadius = 10.0f;
    private float viewAngle = 110.0f;
    private float enemyRotationSpeed = 4.5f;

    public Transform player;
    public LayerMask playerMask;
    public LayerMask obstacleMask;

    public static bool playerInRange = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        FindVisibleTargets();
    }

    void FindVisibleTargets()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    //transform.LookAt(player);
                    /*
                    Quaternion enemyRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, enemyRotation, enemyRotationSpeed * Time.deltaTime);
                    */
                    playerInRange = true;
                    //Debug.Log("Gracz w zasiegu");

                }
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, playerMask))
                {
                    playerInRange = false;
                    //Debug.Log("Gracz poza zasiegiem");
                }
                /*
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    //transform.LookAt(player);
                    
                    Quaternion enemyRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, enemyRotation, enemyRotationSpeed * Time.deltaTime);
                    
                }
                */
            }
        }
    }
    
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    
}
