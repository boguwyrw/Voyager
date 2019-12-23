using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraalRotation : MonoBehaviour
{

    private float graalRotation = 120.0f;

    void Start()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0.0f, graalRotation * Time.deltaTime, 0.0f));
    }

}
