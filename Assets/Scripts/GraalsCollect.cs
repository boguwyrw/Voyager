using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraalsCollect : MonoBehaviour
{
    
    private int numberOfGoldGraal;
    private int numberOfSilverGraal;
    private int numberOfBrownGraal;

    public Text goldGraalNumber;
    public Text silverGraalNumber;
    public Text brownGraalNumber;

    void Start()
    {
        numberOfGoldGraal = 0;
        numberOfSilverGraal = 0;
        numberOfBrownGraal = 0;
        SetGoldGraalCountText();
        SetSilverGraalCountText();
        SetBrownGraalCountText();
    }

    public int GetNumberOfGoldGraal()
    {
        return numberOfGoldGraal;
    }

    public int GetNumberOfSilverGraal()
    {
        return numberOfSilverGraal;
    }

    public int GetNumberOfBrownGraal()
    {
        return numberOfBrownGraal;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoldGraal"))
        {
            other.gameObject.SetActive(false);
            numberOfGoldGraal = numberOfGoldGraal + 1;
            SetGoldGraalCountText();
        }

        if (other.gameObject.CompareTag("SilverGraal"))
        {
            other.gameObject.SetActive(false);
            numberOfSilverGraal = numberOfSilverGraal + 1;
            SetSilverGraalCountText();
        }

        if (other.gameObject.CompareTag("BrownGraal"))
        {
            other.gameObject.SetActive(false);
            numberOfBrownGraal = numberOfBrownGraal + 1;
            SetBrownGraalCountText();
        }
    }

    void SetGoldGraalCountText()
    {
        goldGraalNumber.text = numberOfGoldGraal.ToString();
    }

    void SetSilverGraalCountText()
    {
        silverGraalNumber.text = numberOfSilverGraal.ToString();
    }

    void SetBrownGraalCountText()
    {
        brownGraalNumber.text = numberOfBrownGraal.ToString();
    }

}
