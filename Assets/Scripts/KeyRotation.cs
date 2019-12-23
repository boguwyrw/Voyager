using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotation : MonoBehaviour
{

    private float keyRotation = 80.0f;

    void Update()
    {
        transform.Rotate(new Vector3(0.0f, keyRotation * Time.deltaTime, 0.0f));
    }
}
