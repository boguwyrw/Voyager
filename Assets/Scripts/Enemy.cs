using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject destroyedSystem;
    public Renderer rightHandRenderer;
    public Renderer leftHandRenderer;

    private Rigidbody enemyRigidbody;
    private Renderer enemyRenderer;
    private bool restartEnemyLife = false;
    private int numberOfHits;
    private bool freezeEnemy = false;

    void Start()
    {
        numberOfHits = 0;
        destroyedSystem.SetActive(false);
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        enemyRenderer = GetComponent<Renderer>();
    }
   
    void FixedUpdate()
    {
        
        restartEnemyLife = GameControl.sceneIsReloaded;
        if (restartEnemyLife)
        {
            numberOfHits = 0;
        }

        if (numberOfHits >= 4)
        {
            freezeEnemy = true;
        }
        else
        {
            freezeEnemy = false;
        }

        if (!freezeEnemy)
        {
            InitialEnemySettings();
        }
        else
        {
            EnemyDie();
        }

    }

    public bool GetFreezeEnemy()
    {
        return freezeEnemy;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        { 
            numberOfHits += 1;
        }
    }

    void InitialEnemySettings()
    {
        destroyedSystem.SetActive(false);
        enemyRenderer.material.color = new Color32(255, 255, 255, 255);
        rightHandRenderer.material.color = new Color32(255, 255, 255, 255);
        leftHandRenderer.material.color = new Color32(255, 255, 255, 255);
    }

    void EnemyDie()
    {
        destroyedSystem.SetActive(true);
        enemyRenderer.material.color = new Color32(150, 90, 90, 255);
        rightHandRenderer.material.color = new Color32(150, 90, 90, 255);
        leftHandRenderer.material.color = new Color32(150, 90, 90, 255);
    }

    public int GetNumberOfHits()
    {
        return numberOfHits;
    }

}
