using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public GameObject keysText;
    public GameObject graalsText;
    public GameObject introductionText;
    public GameObject winText;
    public GameObject loseText;
    public GameObject playerHealth;
    public GameObject miniMap;
    public GameObject playButton;
    public GameObject playAgainButton;
    public GameObject quitButton;
    public GameObject mapRawImage;

    public static bool sceneIsReloaded;

    private int healthPoints;
    private int goldGraals;
    private int silverGraals;
    private int brownGraals;

    private GraalsCollect graalsCollect;
    private PlayerHealth playerHealthPoints;
    
    void Awake()
    {
        graalsCollect = GetComponent<GraalsCollect>();
        playerHealthPoints = GetComponent<PlayerHealth>();
    }
    
    void Start()
    {
        graalsCollect = GetComponent<GraalsCollect>();
        playerHealthPoints = GetComponent<PlayerHealth>();
        Time.timeScale = 0;
        keysText.transform.position = new Vector3(0.075f * Screen.width, 0.925f * Screen.height, 0);
        graalsText.transform.position = new Vector3(0.925f * Screen.width, 0.925f * Screen.height, 0);
        introductionText.transform.position = new Vector3(0.5f * Screen.width, 0.825f * Screen.height, 0);
        winText.transform.position = new Vector3(0.5f * Screen.width, 0.825f * Screen.height, 0);
        loseText.transform.position = new Vector3(0.5f * Screen.width, 0.825f * Screen.height, 0);
        playerHealth.transform.position = new Vector3(0.925f * Screen.width, 0.075f * Screen.height, 0);
        miniMap.transform.position = new Vector3(0.075f * Screen.width, 0.175f * Screen.height, 0);
        playButton.transform.position = new Vector3(0.5f * Screen.width, 0.58f * Screen.height, 0);
        playAgainButton.transform.position = new Vector3(0.5f * Screen.width, 0.58f * Screen.height, 0);
        quitButton.transform.position = new Vector3(0.5f * Screen.width, 0.42f * Screen.height, 0);
        playAgainButton.SetActive(false);
        winText.SetActive(false);
        loseText.SetActive(false);
        mapRawImage.SetActive(false);
        sceneIsReloaded = false;
    }

    void Update()
    {
        goldGraals = graalsCollect.GetNumberOfGoldGraal();
        silverGraals = graalsCollect.GetNumberOfSilverGraal();
        brownGraals = graalsCollect.GetNumberOfBrownGraal();
        healthPoints = playerHealthPoints.GetHealth();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            playButton.SetActive(true);
            playButton.GetComponentInChildren<Text>().text = "Resume";
            quitButton.SetActive(true);
            Time.timeScale = 0;
        }

        if (healthPoints == 0)
        {
            Cursor.visible = true;
            playAgainButton.SetActive(true);
            quitButton.SetActive(true);
            loseText.SetActive(true);
            Time.timeScale = 0;
        }

        if ((goldGraals == 3) && (silverGraals == 3) && (brownGraals == 3))
        {
            Cursor.visible = true;
            playButton.SetActive(true);
            quitButton.SetActive(true);
            winText.SetActive(true);
            Time.timeScale = 0;
        }


        if (Input.GetKeyDown(KeyCode.M))
        {
            mapRawImage.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            mapRawImage.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        Cursor.visible = false; // ukrywa kursor myszy w trybie gry
        playButton.SetActive(false);
        quitButton.SetActive(false);
        introductionText.SetActive(false);
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void PlayAgainButton()
    {
        sceneIsReloaded = true;
        SceneManager.LoadScene("PlayGameScene");
    }
}
