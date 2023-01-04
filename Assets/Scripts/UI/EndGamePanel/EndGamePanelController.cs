using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePanelController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI CurrentScore;
    [SerializeField]
    private TMPro.TextMeshProUGUI MaxScore;

    void Start()
    {
        CurrentScore.text = PointManager.Instance.TotalPointGain.ToString();
        MaxScore.text = Player.Instance.HighScore.ToString();
    }



}
