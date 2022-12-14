using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    private string MainMenuName = "MainMenu";

    [SerializeField]
    private Button PauseButton;
    [SerializeField]
    private GameObject PausePanel;
    [SerializeField]
    FadeController FC;

    public void OnPauseButtonClicked()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0.01f;
    }

    public void OnContinueButtonClicked()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnMainMenuButtonClicked()
    {
        StartCoroutine(LoadMainMenu());

        FC.ActivateSlowFadeOut();
    }

    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(0.015f);
        Time.timeScale = 1f;
        if(MusicManager.Instance)
        {
            MusicManager.Instance.SetToMenuMusic();
        }
        SceneManager.LoadScene(MainMenuName);
    }

}
