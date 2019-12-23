using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTest : MonoBehaviour
{

    public GameObject ball;
    public Transform endPointObj;

    private float startX;
    private float startY;
    private float startZ;
    private float distanceZ;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private float speed;

    void Start()
    {
        speed = 5.0f;
        startX = 0.0f;
        startY = 1.0f;
        startZ = 1.0f;
        distanceZ = 25.0f;
        startPosition = new Vector3(startX, startY, startZ);
        ball.transform.position = startPosition;
    }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        
        ball.transform.position = Vector3.MoveTowards(startPosition, endPointObj.transform.position, step);

        //Shoot();
        /*
        if (Input.GetKey(KeyCode.B))
        {
            Shoot();
        }
        */
        /*
        Debug.Log("Wspolrzedna X " + Input.mousePosition.x);
        Debug.Log("Wspolrzedna Y " + Input.mousePosition.y);
        Debug.Log("Wspolrzedna Z " + Input.mousePosition.z);
        */
    }
    /*
    void Shoot()
    {
        float step = speed * Time.deltaTime;

        ball.transform.position = startPosition;
        //endPosition = new Vector3(startX += Time.deltaTime, startY += Time.deltaTime, startZ += Time.deltaTime);
        endPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceZ);
        //ball.transform.position = endPosition;
        ball.transform.position = Vector3.MoveTowards(startPosition, endPointObj.position, step);
        //ball.transform.position = Vector3.Lerp(startPosition, endPosition, 10.0f * Time.deltaTime);
    }
    */
}
