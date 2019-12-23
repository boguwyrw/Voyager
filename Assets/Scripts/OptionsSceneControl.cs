using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsSceneControl : MonoBehaviour
{

    public GameObject controlText;
    public GameObject W_Text;
    public GameObject W_DescriptionText;
    public GameObject S_Text;
    public GameObject S_DescriptionText;
    public GameObject A_Text;
    public GameObject A_DescriptionText;
    public GameObject D_Text;
    public GameObject D_DescriptionText;
    public GameObject leftMouseButtonText;
    public GameObject leftMouseButtonDescriptionText;
    public GameObject movingMouseText;
    public GameObject movingMouseDescriptionText;
    public GameObject backButton;

    void Start()
    {
        controlText.transform.position = new Vector3(0.5f * Screen.width, 0.925f * Screen.height, 0);
        W_Text.transform.position = new Vector3(0.35f * Screen.width, 0.775f * Screen.height, 0);
        W_DescriptionText.transform.position = new Vector3(0.65f * Screen.width, 0.775f * Screen.height, 0);
        S_Text.transform.position = new Vector3(0.35f * Screen.width, 0.675f * Screen.height, 0);
        S_DescriptionText.transform.position = new Vector3(0.65f * Screen.width, 0.675f * Screen.height, 0);
        A_Text.transform.position = new Vector3(0.35f * Screen.width, 0.575f * Screen.height, 0);
        A_DescriptionText.transform.position = new Vector3(0.65f * Screen.width, 0.575f * Screen.height, 0);
        D_Text.transform.position = new Vector3(0.35f * Screen.width, 0.475f * Screen.height, 0);
        D_DescriptionText.transform.position = new Vector3(0.65f * Screen.width, 0.475f * Screen.height, 0);
        leftMouseButtonText.transform.position = new Vector3(0.35f * Screen.width, 0.375f * Screen.height, 0);
        leftMouseButtonDescriptionText.transform.position = new Vector3(0.65f * Screen.width, 0.375f * Screen.height, 0);
        movingMouseText.transform.position = new Vector3(0.35f * Screen.width, 0.275f * Screen.height, 0);
        movingMouseDescriptionText.transform.position = new Vector3(0.65f * Screen.width, 0.275f * Screen.height, 0);
        backButton.transform.position = new Vector3(0.5f * Screen.width, 0.095f * Screen.height, 0);
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }


}
