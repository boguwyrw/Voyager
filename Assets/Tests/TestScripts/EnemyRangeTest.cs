using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeTest : MonoBehaviour
{

    private Vector3 positionPlayerEnemy;
    private GameObject player;
    private GameObject enemyGun;
    private Vector3 enemyBulletStartPosition;
    private bool startsShooting = false;
    private float enemyBulletSpeed = 400.0f;
    private float fireRate = 1.5f;
    private float nextFire;
    private float enemyRotationSpeed = 4.5f;
    private int playerHitEnemy = 0;
    private bool isEnemyFreeze = false;

    public GameObject enemy;
    public Rigidbody enemyBullet;

    void Start()
    {
        nextFire = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        enemyGun = GameObject.FindGameObjectWithTag("EnemyGun");
    }

    void FixedUpdate()
    {
        enemyBulletStartPosition = enemyGun.transform.position;
        positionPlayerEnemy = player.transform.position - enemy.transform.position;

        playerHitEnemy = FindObjectOfType<Enemy>().GetNumberOfHits();
        isEnemyFreeze = FindObjectOfType<Enemy>().GetFreezeEnemy();

        if (playerHitEnemy >= 4)
        {
            startsShooting = false;
        }

        if (startsShooting)
        {
            if (Time.time > nextFire)
            {
                Rigidbody clone;
                clone = Instantiate(enemyBullet, enemyBulletStartPosition, transform.rotation);
                clone.velocity = transform.TransformDirection(Vector3.forward * enemyBulletSpeed * Time.deltaTime);
                nextFire = Time.time + fireRate;
            }
        }

        //Debug.Log("Liczba trafien: " + playerHitEnemy);

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isEnemyFreeze)
        {
            //Debug.Log("Jestes widoczny");
            //enemy.transform.LookAt(other.transform); - to jest najprostrze
            Quaternion enemyRotation = Quaternion.LookRotation(positionPlayerEnemy, Vector3.up);
            enemy.transform.rotation = Quaternion.Slerp(transform.rotation, enemyRotation, enemyRotationSpeed * Time.deltaTime);
            startsShooting = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            startsShooting = false;
        }
    }

}
