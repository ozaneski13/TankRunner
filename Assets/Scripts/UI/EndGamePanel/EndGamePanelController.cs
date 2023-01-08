using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePanelController : MonoBehaviour
{
    [SerializeField]
    public TMPro.TextMeshProUGUI CurrentScore;
    [SerializeField]
    public TMPro.TextMeshProUGUI HighScore;

    void Start()
    {
        CurrentScore.text = PointManager.Instance.TotalPointGain.ToString();
        HighScore.text = Player.Instance.HighScore.ToString();
        Player.Instance.Tank.GetStatus();
    }



}
