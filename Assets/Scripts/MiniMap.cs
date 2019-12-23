using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public Transform playerPosition;

    void LateUpdate()
    {
        Vector3 miniMapPosition = playerPosition.position;
        miniMapPosition.y = transform.position.y;
        transform.position = miniMapPosition;
    }
}
