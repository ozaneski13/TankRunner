using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(var tankModel in Player.Instance.TankPrefabs)
        {
            tankModel.gameObject.SetActive(false);
        }

        Player.Instance.TankPrefabs[(int)(Player.Instance.CurrentTank)].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
