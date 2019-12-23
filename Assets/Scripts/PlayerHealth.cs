using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider playerHealthSlider;
    public Image playerHealthFill;
    public Image playerHealthBackground;
    public Text playerHealthPoints;

    public static int health;

    private int healthMax = 100;
    private bool playAgain = false;

    void Start()
    {
        health = healthMax;
        playerHealthSlider.maxValue = health;
        playerHealthPoints.color = new Color(0, 255, 0);
        playerHealthFill.color = new Color(0, 255, 0);
        playerHealthBackground.color = new Color(255, 0, 0);
    }

    void Update()
    {
 
        SetPlayerHealthPointsText();

        playerHealthSlider.value = health;

        playAgain = GameControl.sceneIsReloaded;

        if(playAgain)
        {
            health = healthMax;
        }

        if (health == 0)
        {
            playerHealthSlider.image.color = new Color(255, 0, 0);
            playerHealthPoints.color = new Color(255, 0, 0);
            
        }
        else
        {
            playerHealthSlider.image.color = new Color(0, 255, 0);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FirstAidKit"))
        {
            if (health < 100)
            { 
                health += 20;
            }
            other.gameObject.SetActive(false);
            //playerHealthSlider.maxValue = health;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            health -= 20;
        }
    }

    void SetPlayerHealthPointsText()
    {
        playerHealthPoints.text = "Health points: " + health.ToString();
    }

}
