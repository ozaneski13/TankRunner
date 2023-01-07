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
    private bool isGameContinue = true;

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
        if (isGameContinue)
        {
            CalculateScore();
            TextMeshPro.text = ((int)score).ToString();
        }
    }

    public void SetGameContinue(bool inputBool)
    {
        isGameContinue= inputBool;
    }

    public float GetScore()
    {
        return score;
    }

}
