using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private FadeController _fC = null;

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
        StartCoroutine(LoadNewScene("GameScene"));
        _fC.ActivateFadeOut();
    }

    public void OpenMarket()
    {
        StartCoroutine(LoadNewScene("MarketScene"));
        _fC.ActivateFadeOut();
    }

    public void QuitGame()
    {
        StartCoroutine(QuitWithDelay());
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        yield return new WaitForSeconds(.8f);

        if(sceneName == "GameScene")
            MusicManager.Instance.SetToGameMusic();

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator QuitWithDelay()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}