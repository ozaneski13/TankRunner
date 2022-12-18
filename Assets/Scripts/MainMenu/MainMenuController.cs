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
        SceneManager.LoadScene("MarketScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
