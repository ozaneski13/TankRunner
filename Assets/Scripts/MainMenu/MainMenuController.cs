using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    FadeController fC;

    private void Start()
    {
        foreach (var tankModel in Player.Instance.TankPrefabs)
        {
            tankModel.gameObject.SetActive(false);
        }

        Player.Instance.Tank.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation ;
    }

    public void PlayGame()
    {
        Player.Instance.TankPrefabs[(int)(Player.Instance.CurrentTank)].gameObject.SetActive(true);
        Player.Instance.Tank.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        StartCoroutine(LoadNewScene("SampleScene"));
        fC.ActivateFadeOut();
    }

    public void OpenMarket()
    {
        StartCoroutine(LoadNewScene("MarketScene"));
        fC.ActivateFadeOut();
    }

    public void QuitGame()
    {
        StartCoroutine(QuitWithDelay());
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        yield return new WaitForSeconds(.8f);
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
