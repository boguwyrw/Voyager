using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSwitching : MonoBehaviour
{

    public int selectedEquipment = 0;

    void Start()
    {
        SelectEquipment();
    }

    void FixedUpdate()
    {
        int previousSelectedEquipment = selectedEquipment;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedEquipment = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedEquipment = 1;
        }

        if (previousSelectedEquipment != selectedEquipment)
        {
            SelectEquipment();
        }
    }

    void SelectEquipment()
    {
        int i = 0;
        foreach (Transform equipment in transform)
        {
            if (i == selectedEquipment)
            {
                equipment.gameObject.SetActive(true);
            }
            else
            {
                equipment.gameObject.SetActive(false);
            }

            i++;

        }
    }

}
