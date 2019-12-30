using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorBasement : MonoBehaviour
{

    public GameObject mainDoorBasementController;

    void Start()
    {
        mainDoorBasementController.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainDoorBasementController.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainDoorBasementController.SetActive(false);
        }
    }

    public void YesAnswer()
    {
        Destroy(gameObject);
        mainDoorBasementController.SetActive(false);
    }

    public void NoAnswer()
    {
        mainDoorBasementController.SetActive(false);
    }
}
