using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI TextMeshPro;
    
    private float score = 0;

    private void CalculateScore()
    {
        score = PointManager.Instance.TotalPointGain;
    }

    private void FixedUpdate()
    {
        CalculateScore();
        TextMeshPro.text = score.ToString();
    }

}
