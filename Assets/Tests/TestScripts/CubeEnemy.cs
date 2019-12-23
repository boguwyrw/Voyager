using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{

    private int playerHitEnemy = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Debug.Log("Liczba trafien w Cube: " + playerHitEnemy.ToString());
    }

    void OnCollisionEnter(Collision collision) // zeby to zadzialalo to obkiekt musi miec Rigidbody, do OnTrigger Rigidbody nie jest potrzebne
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //playerHitEnemy += 1;
            Debug.Log("Trafiles");
        }
    }

}
