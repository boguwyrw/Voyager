using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public GameObject ground;
    private float offsetY = 2.0f;
    private float offsetZ = 0.5f;

    void Start()
    {
        //transform.position = new Vector3(transform.position.x, offsetY, transform.position.z);
        //offsetY = transform.position.y - ground.transform.position.y;
        transform.position = new Vector3(transform.position.x, offsetY, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        { 
            transform.position = new Vector3(2, offsetY, offsetZ);
            offsetZ++;
        }
    }
}
