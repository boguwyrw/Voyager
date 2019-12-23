using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Enemy Shooting
    private GameObject player;
    private Vector3 enemyBulletStartPosition;
    private bool startsShooting = false;
    private float enemyBulletSpeed = 580.0f;
    private float fireRate = 1.2f;
    private float nextFire;
    private int playerHitEnemy = 0;
    private bool isEnemyFreeze = false;
    private bool isSeeingPlayer = false;

    public GameObject enemyGun;
    public Rigidbody enemyBullet;

    // Enemy Find Player
    private float viewAngle = 130.0f;

    public LayerMask playerMask;
    public LayerMask solidElementsMask;

    // Enemy Patrol
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private int lastWaypointIndex;
    private float minimumDistance = 0.05f;
    private float movementSpeed = 4.0f;
    private float rotationSpeed = 5.0f;
    private float enemyRange = 0.0f;
    private SphereCollider enemySphereCollider;

    public List<Transform> waypointPath_01 = new List<Transform>();

    private Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void Start()
    {
        enemySphereCollider = GetComponent<SphereCollider>();
        enemyRange = enemySphereCollider.radius;
        nextFire = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");

        lastWaypointIndex = waypointPath_01.Count - 1;
        targetWaypoint = waypointPath_01[targetWaypointIndex];
    }

    void Update()
    {
        isEnemyFreeze = enemy.GetFreezeEnemy();
        playerHitEnemy = enemy.GetNumberOfHits();
 
        if (!isEnemyFreeze)
        {
            if (!isSeeingPlayer)
            {
                EnemyPatrol();
            }
            else
            {
                EnemyFindPlayer();
                if (playerHitEnemy >= 4)
                {
                    startsShooting = false;
                }
                if (startsShooting)
                {
                    EnemyShooting();
                }
            }

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            if(angle < viewAngle*0.5f)
            { 
                RaycastHit raycast;
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out raycast, enemyRange * 2))
                {
                    if (raycast.collider.gameObject.CompareTag("Player"))
                    {
                        isSeeingPlayer = true;
                        startsShooting = true;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isSeeingPlayer = false;
        }
    }

    void EnemyShooting()
    {
        enemyBulletStartPosition = enemyGun.transform.position;

        if (startsShooting)
        {
            if (Time.time > nextFire)
            {
                Rigidbody bulletClone;
                bulletClone = Instantiate(enemyBullet, enemyBulletStartPosition, transform.rotation);
                bulletClone.velocity = transform.TransformDirection(Vector3.forward * enemyBulletSpeed * Time.deltaTime);
                nextFire = Time.time + fireRate;
            }
        }
    }
    
    void EnemyFindPlayer()
    {
        Quaternion enemyRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, enemyRotation, rotationSpeed * Time.deltaTime);
 
    }

    void EnemyPatrol()
    {
        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationSpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementSpeed * Time.deltaTime);
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minimumDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypointPath_01[targetWaypointIndex];
    }

}
