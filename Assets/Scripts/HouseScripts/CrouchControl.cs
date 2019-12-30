using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchControl : MonoBehaviour
{

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            transform.localScale = new Vector3(1.0f, 0.625f, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        //Instantiate as a child of gameobject
    }
}
