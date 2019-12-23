using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootTest : MonoBehaviour
{
    private float range = 150.0f;
    private float playerBulletSpeed = 200.0f;
    private Vector3 bulletStartPosition;

    public Rigidbody playerBullet;
    public Camera playerCamera;
    public GameObject enemy;
    public GameObject playerGun;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        bulletStartPosition = playerGun.transform.position;

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody clone;
            clone = Instantiate(playerBullet, bulletStartPosition, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * playerBulletSpeed * Time.deltaTime);
        }

        /*
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, range))
        {
            Debug.Log("Kolizja z " + raycastHit.collider.gameObject.name);
            Debug.Log("Dystans: " + raycastHit.distance.ToString());

        }

        float distanceX = enemy.transform.position.x - transform.position.x;
        Debug.Log("X: " + distanceX);
        */
    }
}
