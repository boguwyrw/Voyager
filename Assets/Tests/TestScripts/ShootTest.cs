using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTest : MonoBehaviour
{

    public Rigidbody playerBullet;

    public GameObject playerGun;
    public GameObject endPoint;

    private Vector3 bulletStartPosition;
    private float offsetZ = 1.0f;
    private float offsetY = 0.25f;
    private float playerBulletSpeed = 250.0f;

    //private Vector3 bulletDirection;

    void Start()
    {
        //endPoint.transform.position = new Vector3(Screen.width/2, Screen.height/2, 10.0f);
    }

    void FixedUpdate()
    {
        //TestShoot();
        //OneMoreTestShoot();
        CosZRayCast();
    }

    void OneMoreTestShoot()
    {
        Debug.Log("X: " + endPoint.transform.position.x);
        Debug.Log("Y: " + endPoint.transform.position.y);
        Debug.Log("Z: " + endPoint.transform.position.z);

        bulletStartPosition = playerGun.transform.position;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Rigidbody clone;
            clone = Instantiate(playerBullet, bulletStartPosition, transform.rotation);
            clone.velocity = transform.TransformDirection(endPoint.transform.forward * playerBulletSpeed * Time.deltaTime);
            //clone = Instantiate(playerBullet, bulletStartPosition, Quaternion.FromToRotation(Vector3.up, endPoint.transform.position));
            //clone.transform.LookAt(endPoint.transform);
            //clone.transform.Translate(Vector3.forward * playerBulletSpeed * Time.deltaTime);

        }

    }

    void CosZRayCast()
    {
        Ray ray = Camera.current.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 250))
        {
            Debug.Log("Kolizja z " + raycastHit.collider.gameObject.name);
            Debug.Log("Dystans: " + raycastHit.distance.ToString());
        }
    }

    void TestShoot()
    {
        //Ray ray = Camera.current.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
        //bulletStartPosition = new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z + offsetZ);
        bulletStartPosition = playerGun.transform.position;
        //bulletDirection = new Vector3(Screen.width/2, Screen.height/2, 2.0f);
        if (Input.GetKeyDown(KeyCode.F))
        {
            Rigidbody clone;
            clone = Instantiate(playerBullet, bulletStartPosition, transform.rotation);
            //clone.velocity = transform.TransformDirection(Vector3.forward * playerBulletSpeed * Time.deltaTime);
            //clone.velocity = transform.TransformDirection(endPoint.transform.forward * playerBulletSpeed * Time.deltaTime);
            clone.AddForce(endPoint.transform.forward * playerBulletSpeed * Time.deltaTime);
        }
    }

}
