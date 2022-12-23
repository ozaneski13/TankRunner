using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{

    public static MarketManager Instance = null;

    [SerializeField]
    public List<GameObject> Tanks;
    [SerializeField]
    public Vector3 initialLocation = new Vector3(0, 0, 2f);
    [SerializeField]
    private Button SelectButton;
    static bool isMoveActive = false;
    float ChangeSpeed  = 10f;
    int RotationTankIndex = 0;
    static int SelectedTankIndex = 0;

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
    }

    private void SortTanks()
    {
        for (int i = 0; i < Tanks.Count; i++)
        {
            Tanks[i].transform.position = initialLocation + new Vector3(0, 0, i * 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckSelectButtonStatus();
        //Debug.Log("SelectedTankIndex:" + SelectedTankIndex);    
    }


    public void ChangeTanktToLeft()
    {
        if (isMoveActive == false)
        {
            if(RotationTankIndex != 0)
            {
                for (int i = 0; i < Tanks.Count; i++)
                {
                    StartCoroutine(MoveObjects(Tanks[i], 1));
                }
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
                for (int i = 0; i < Tanks.Count; i++)
                {
                    StartCoroutine(MoveObjects(Tanks[i], -1));
                }
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
            if (tankObject.transform.position == nextLocation)
            {
                isMoveActive= false;
                yield break;
            }

            // Wait for the next frame before continuing the loop
            yield return null;
        }
    }

    private void CheckSelectButtonStatus()
    {
        if(SelectedTankIndex == RotationTankIndex)
        {
            if(SelectButton.IsActive())
            {
                SelectButton.gameObject.SetActive(false);
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

    public void OnSelectButtonClicked()
    {
        SelectedTankIndex = RotationTankIndex;
    }

    public void OnMainMenuClicked()
    {
        StartCoroutine(LoadMainMenuWithDelay());
    }

    IEnumerator LoadMainMenuWithDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }

}
