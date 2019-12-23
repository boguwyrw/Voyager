using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    private float timeToDestroy;

    void Start()
    {
        timeToDestroy = 2.8f;
    }

    void FixedUpdate()
    {
        timeToDestroy -= Time.deltaTime;
        //Debug.Log("Czas: " + timeToDestroy.ToString("F1"));
        if (timeToDestroy < 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
