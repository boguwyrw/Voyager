using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Rigidbody playerBullet;
    public GameObject playerGun;

    private Vector3 bulletStartPosition;
    private float playerBulletSpeed = 600.0f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        bulletStartPosition = playerGun.transform.position;

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody bulletClone;
            bulletClone = Instantiate(playerBullet, bulletStartPosition, transform.rotation);
            bulletClone.velocity = transform.TransformDirection(Vector3.forward * playerBulletSpeed * Time.deltaTime);
        }
    }
}
