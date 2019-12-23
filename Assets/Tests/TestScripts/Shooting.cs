using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Rigidbody playerBullet;

    private float playerBulletSpeed = 500.0f;
    private float offsetY = 0.8f;
    private float offsetZ = 1.25f;
    private Vector3 bulletStartPosition;
    private Vector3 bulletShootingPosition;
    
    void Update()
    {
        bulletStartPosition = new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z + offsetZ);
        bulletShootingPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50.0f);
        /*
        if (Input.GetKeyDown(KeyCode.F))
        { 
            PlayerShoot();
        }
        */
        // to ponizej dziala :-)
        RaycastHit raycastHit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, 500.0f))
        if (Physics.Raycast(transform.position, Vector3.forward, out raycastHit, 500.0f))
        {
            //Debug.Log(raycastHit.transform.name);
            if (Input.GetKeyDown(KeyCode.F))
            {
                PlayerShoot();
            }
        }

    }

    void PlayerShoot()
    {
        
        Rigidbody clone;
        //clone = Instantiate(playerBullet, transform.position, transform.rotation);
        clone = Instantiate(playerBullet, bulletStartPosition, transform.rotation);
        clone.velocity = transform.TransformDirection(Vector3.forward * playerBulletSpeed * Time.deltaTime);
        

        /*
        RaycastHit raycastHit;
        if (Physics.Raycast(transform.position, transform.position, out raycastHit, distance))
        {
            //Debug.Log(raycastHit.transform.name);

            Rigidbody cloneBullet;
            cloneBullet = Instantiate(playerBullet, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
            cloneBullet.transform.position = transform.position + transform.forward * 2;
            cloneBullet.velocity = transform.TransformDirection(Vector3.forward * playerBulletSpeed * Time.deltaTime);
        }
        */
    }

}
