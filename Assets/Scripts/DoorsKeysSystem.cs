using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorsKeysSystem : MonoBehaviour
{

    private int numberOfRedKey = 0;
    private int numberOfBlueKey = 0;
    private int numberOfGreenKey = 0;
    private float messageTime = 2.0f;
    private float temporaryMessageTime = 0.0f;
    private bool isInRange = false;

    public Text redKeyNumber;
    public Text blueKeyNumber;
    public Text greenKeyNumber;

    public Text redDoor;
    public Text blueDoor;
    public Text greenDoor;

    void Start()
    {
        SetRedKeyCountText();
        SetBlueKeyCountText();
        SetGreenKeyCountText();
        NoMessageDoors();
        temporaryMessageTime = messageTime;
    }

    void FixedUpdate()
    {

        if(isInRange)
        {
            temporaryMessageTime -= Time.deltaTime;
        }
        //Debug.Log("Zasieg: " + isInRange.ToString());
        //Debug.Log("Czas: " + temporaryMessageTime.ToString());
        if (temporaryMessageTime <= 0.0f)
        {
            NoMessageDoors();
            isInRange = false;
            temporaryMessageTime = messageTime;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        // funkcjonalnosc dla kluczy
        if (other.gameObject.CompareTag("RedKey"))
        {
            other.gameObject.SetActive(false);
            numberOfRedKey = numberOfRedKey + 1;
            SetRedKeyCountText();
        }
        if (other.gameObject.CompareTag("BlueKey"))
        {
            other.gameObject.SetActive(false);
            numberOfBlueKey = numberOfBlueKey + 1;
            SetBlueKeyCountText();
        }
        if (other.gameObject.CompareTag("GreenKey"))
        {
            other.gameObject.SetActive(false);
            numberOfGreenKey = numberOfGreenKey + 1;
            SetGreenKeyCountText();
        }

        // funkcjonalnosc dla drzwi
        if (other.gameObject.CompareTag("RedDoor") && (numberOfRedKey > 0))
        {
            other.gameObject.SetActive(false);
            numberOfRedKey = numberOfRedKey - 1;
            SetRedKeyCountText();
        }
        if (other.gameObject.CompareTag("BlueDoor") && (numberOfBlueKey > 0))
        {
            other.gameObject.SetActive(false);
            numberOfBlueKey = numberOfBlueKey - 1;
            SetBlueKeyCountText();
        }
        if (other.gameObject.CompareTag("GreenDoor") && (numberOfGreenKey > 0))
        {
            other.gameObject.SetActive(false);
            numberOfGreenKey = numberOfGreenKey - 1;
            SetGreenKeyCountText();
        }

        // funkcjonalnosc dla drzwi i braku kluczy
        if (other.gameObject.CompareTag("RedDoor") && (numberOfRedKey == 0))
        {
            isInRange = true;
            redDoor.text = "Brak czerwonych kluczy";
        }
        if (other.gameObject.CompareTag("BlueDoor") && (numberOfBlueKey == 0))
        {
            isInRange = true;
            blueDoor.text = "Brak niebieskich kluczy";
        }
        if (other.gameObject.CompareTag("GreenDoor") && (numberOfGreenKey == 0))
        {
            isInRange = true;
            greenDoor.text = "Brak zielonych kluczy";
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RedDoor") || other.gameObject.CompareTag("BlueDoor") || other.gameObject.CompareTag("GreenDoor"))
        {
            NoMessageDoors();
        }
    }

    void SetRedKeyCountText()
    {
        redKeyNumber.text = numberOfRedKey.ToString();
    }

    void SetBlueKeyCountText()
    {
        blueKeyNumber.text = numberOfBlueKey.ToString();
    }

    void SetGreenKeyCountText()
    {
        greenKeyNumber.text = numberOfGreenKey.ToString();
    }

    void NoMessageDoors()
    {
        redDoor.text = "";
        blueDoor.text = "";
        greenDoor.text = "";
    }

}
