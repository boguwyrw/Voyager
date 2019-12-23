using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraalsCollect : MonoBehaviour
{

    public static int numberOfGoldGraal = 0;
    public static int numberOfSilverGraal = 0;
    public static int numberOfBrownGraal = 0;

    public Text goldGraalNumber;
    public Text silverGraalNumber;
    public Text brownGraalNumber;

    void Start()
    {
        SetGoldGraalCountText();
        SetSilverGraalCountText();
        SetBrownGraalCountText();
    }

    void Update()
    {
        
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
