using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{

    private void Start()
    {
        foreach (var tankModel in Player.Instance.TankPrefabs)
        {
            tankModel.gameObject.SetActive(false);
        }
    }

    public void PlayGame()
    {
        Player.Instance.TankPrefabs[(int)(Player.Instance.CurrentTank)].gameObject.SetActive(true);
        StartCoroutine(LoadNewScene("SampleScene"));
    }

    public void OpenMarket()
    {
        StartCoroutine(LoadNewScene("MarketScene"));
    }

    public void QuitGame()
    {
        StartCoroutine(QuitWithDelay());
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        if(sceneName == "SampleScene")
            MusicManager.Instance.SetToGameMusic();
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator QuitWithDelay()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
