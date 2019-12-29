using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageControl : MonoBehaviour
{

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(0.95f * Screen.height, 0.95f * Screen.height);
            //new Rect(0.1f * Screen.width, 0.1f * Screen.height, 0.8f * Screen.width, 0.8f * Screen.height);
    }

    void Update()
    {
        
    }
}
