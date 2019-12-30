using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    public Rigidbody playerBullet;
    public GameObject playerGun;
    
    private Vector3 bulletStartPosition;
    private float playerBulletSpeed = 1100.0f;
    private float fireRate = 0.8f;
    private float nextFire;

    void Start()
    {
        nextFire = Time.time;
    }

    void FixedUpdate()
    {
        bulletStartPosition = playerGun.transform.position;

        if (Input.GetButtonDown("Fire1") && (Time.time > nextFire))
        {
            Rigidbody bulletClone;
            bulletClone = Instantiate(playerBullet, bulletStartPosition, transform.rotation);
            bulletClone.velocity = transform.TransformDirection(Vector3.forward * playerBulletSpeed * Time.deltaTime);
            nextFire = Time.time + fireRate;
        }
    }
}
