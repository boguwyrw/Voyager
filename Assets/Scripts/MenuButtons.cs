using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{



    public void StartButton()
    {
        SceneManager.LoadScene("PlayGameScene");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
