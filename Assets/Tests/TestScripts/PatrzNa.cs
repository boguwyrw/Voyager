using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrzNa : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target);
        //transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
    }
}
