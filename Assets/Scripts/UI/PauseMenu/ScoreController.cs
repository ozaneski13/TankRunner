using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI TextMeshPro;
    
    private float score = 0;
    private float roadScore = 0;
    private bool isGameContinues = true;

    private void CalculateScore()
    {
        roadScore += RoadManager.Instance.RoadTreadmill.CurrentSpeed;
        score = PointManager.Instance.TotalPointGain + roadScore;
        if(Player.Instance.HighScore < (int)score)
        {
            Player.Instance.HighScore = (int)score;
        }
    }

    private void FixedUpdate()
    {
        if (isGameContinues)
        {
            CalculateScore();
            TextMeshPro.text = ((int)score).ToString();
        }
    }

    public void SetGameContinues(bool inputBool)
    {
        isGameContinues= inputBool;
    }

    public float GetScore()
    {
        return score;
    }

}
