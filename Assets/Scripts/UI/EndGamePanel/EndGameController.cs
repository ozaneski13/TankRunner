using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    private string MainMenuName = "MainMenu";
    private string GameSceneName = "GameScene";

    [SerializeField]
    private GameObject EndGamePanel;
    [SerializeField]
    FadeController FC;

    private void Start()
    {
        //DEBUG MODE
        //StartCoroutine(DecreaseHealth());
    }
    IEnumerator DecreaseHealth()
    {
        yield return new WaitForSeconds(1f);
        Player.Instance.Tank.TankHealth.DecreaseHealth(100);
    }

    private void LateUpdate()
    {
        if (Player.Instance.Tank.TankHealth.GetHealth() < 1)
        {
            ActivateEndGamePanel();
        }
    }

    private void ActivateEndGamePanel()
    {
        EndGamePanel.SetActive(true);
        Time.timeScale = 0.01f;
    }

    public void OnRestartButtonClicked()
    {
        //EndGamePanel.SetActive(false);
        StartCoroutine(LoadGameScene());
        FC.ActivateSlowFadeOut();
    }

    public void OnMainMenuButtonClicked()
    {
        StartCoroutine(LoadMainMenu());

        FC.ActivateSlowFadeOut();
    }

    private IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(0.015f);
        Time.timeScale = 1f;
        if (MusicManager.Instance)
        {
            MusicManager.Instance.SetToGameMusic();
        }
        Player.Instance.Tank.TankHealth.IncreaseHealth(1000);
        SceneManager.LoadScene(GameSceneName);
    }

    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(0.015f);
        Time.timeScale = 1f;
        if (MusicManager.Instance)
        {
            MusicManager.Instance.SetToMenuMusic();
        }
        Player.Instance.Tank.TankHealth.IncreaseHealth(1000);
        SceneManager.LoadScene(MainMenuName);
    }

    
}
