using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{

    public string MainMenuName = "MainMenu";
    public string GameSceneName = "GameScene";

    public static MarketManager Instance = null;

    [SerializeField]
    public List<GameObject> Tanks;
    [SerializeField]
    public GameObject TanksParentGameObject;
    [SerializeField]
    public Vector3 initialLocation = new Vector3(0, 0, 2f);
    [SerializeField]
    private Button SelectButton;
    [SerializeField]
    private Button BuyButton;
    [SerializeField]
    private TMPro.TextMeshProUGUI GoldCountText;
    [SerializeField]
    private Image LockImage;
    [SerializeField]
    public List<int> TanksPerPrice;
    static bool isMoveActive = false;
    float ChangeSpeed = 10f;
    int RotationTankIndex = 0;
    [SerializeField]
    FadeController fC;
    //static int SelectedTankIndex = 0;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this) 
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SortTanks();

        if(Player.Instance!= null)
        {
            GoldCountText.text = Player.Instance.CollectedGoldCount.ToString();
            DeactivateCurrentTankModel();
        }
        else
        {
            Debug.LogError("Player does not exist");
        }
    }

    private void DeactivateCurrentTankModel()
    {

        Player.Instance.TankPrefabs[(int)(Player.Instance.CurrentTank)].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckSelectButtonStatus();
        CheckBuyButtonStatus();
        //Debug.Log("SelectedTankIndex:" + SelectedTankIndex);    
    }

    private void SortTanks()
    {
        for (int i = 0; i < Tanks.Count; i++)
        {
            Tanks[i].transform.position = initialLocation + new Vector3(0, 0, i * 5f);
        }
    }

    
    public void ChangeTanktToLeft()
    {
        if (isMoveActive == false)
        {
            if(RotationTankIndex != 0)
            {
                StartCoroutine(MoveObjects(TanksParentGameObject.gameObject, 1));
                /*for (int i = 0; i < Tanks.Count; i++)
                {
                    StartCoroutine(MoveObjects(Tanks[i], 1));
                }*/
                RotationTankIndex--;
            }
        }
    }

    public void ChangeTanktToRight()
    {
        if (isMoveActive == false)
        {
            if (RotationTankIndex != Tanks.Count-1)
            {
                StartCoroutine(MoveObjects(TanksParentGameObject.gameObject, -1));
                /*for (int i = 0; i < Tanks.Count; i++)
                {
                    StartCoroutine(MoveObjects(Tanks[i], -1));
                }*/
                RotationTankIndex++;
            }
        }
    }

    private IEnumerator MoveObjects(GameObject tankObject, int v)
    {
        Vector3 nextLocation = new Vector3(tankObject.transform.position.x,
                                           tankObject.transform.position.y,
                                           tankObject.transform.position.z + v * 5f);
        isMoveActive = true;

        while (true)
        {
            // Move the object towards the end position
            tankObject.transform.position = Vector3.Lerp(tankObject.transform.position, nextLocation, ChangeSpeed * Time.deltaTime);

            // If the object has reached the end position, stop the coroutine
            if (tankObject.transform.position.z < nextLocation.z + 0.02f && tankObject.transform.position.z > nextLocation.z - 0.02f)
            {
                tankObject.transform.position = nextLocation;
                isMoveActive = false;
                yield break;
            }

            // Wait for the next frame before continuing the loop
            yield return null;
        }
    }

    private void CheckSelectButtonStatus()
    {
        if((int)(Player.Instance.CurrentTank) == RotationTankIndex)
        {
            if(SelectButton.IsActive())
            {
                if (Player.Instance.BoughtTanks.Contains((ETank)RotationTankIndex))
                {
                    SelectButton.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (!SelectButton.IsActive())
            {
                SelectButton.gameObject.SetActive(true);
            }
        }
    }

    private void CheckBuyButtonStatus()
    {
        if (Player.Instance.BoughtTanks.Contains((ETank)RotationTankIndex))
        {
            if (BuyButton.IsActive())
            {
                BuyButton.gameObject.SetActive(false);
                LockImage.gameObject.SetActive(false);
            }
        }
        else
        {
            if (!BuyButton.IsActive())
            {
                BuyButton.gameObject.SetActive(true);
                LockImage.gameObject.SetActive(true);
            }
        }
    }

    public void OnSelectButtonClicked()
    {
        if(Player.Instance.BoughtTanks.Contains((ETank)(RotationTankIndex)))
        {
            Player.Instance.CurrentTank = (ETank)(RotationTankIndex);
        }
        //SelectedTankIndex = RotationTankIndex;
    }

    public void OnBuyButtonClicked()
    {
        if(Player.Instance.CollectedGoldCount >= TanksPerPrice[RotationTankIndex])
        {
            Player.Instance.BoughtTanks.Add((ETank)RotationTankIndex);
            Player.Instance.CollectedGoldCount -= TanksPerPrice[RotationTankIndex];
            GoldCountText.text = Player.Instance.CollectedGoldCount.ToString();
        }
    }

    public void OnMainMenuClicked()
    {
        ActivateCurrentTankModel();
        StartCoroutine(LoadMainMenuWithDelay());
        fC.ActivateFadeOut();
    }

    public void OnPlayButtonClicked()
    {
        ActivateCurrentTankModel();
        StartCoroutine(LoadGameSceneuWithDelay());
        fC.ActivateFadeOut();
    }

    private void ActivateCurrentTankModel()
    {
        Player.Instance.TankPrefabs[(int)(Player.Instance.CurrentTank)].gameObject.SetActive(true);
    }

    IEnumerator LoadMainMenuWithDelay()
    {
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(MainMenuName);
    }

    IEnumerator LoadGameSceneuWithDelay()
    {
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(GameSceneName);
    }
}
