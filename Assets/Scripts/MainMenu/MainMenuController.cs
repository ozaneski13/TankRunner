using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenMarket()
    {
        Debug.Log("Open Market Work in Progress");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
