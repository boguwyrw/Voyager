using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{

    public Transform playerEndPosition;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.B))
        {
            transform.position = Vector3.MoveTowards(transform.position, playerEndPosition.position, 3.0f * Time.deltaTime);
        }
    }
}
