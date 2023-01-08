using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    
    [SerializeField]
    private TMPro.TextMeshProUGUI TextMeshPro;

    private float score = 0;
    private float roadScore = 0;
    private float obstacleScore = 0;
    private bool isGameContinue = true;

    private void CalculateScore()
    {
        score = PointManager.Instance.TotalPointGain + roadScore + obstacleScore;
        TextMeshPro.text = ((int)score).ToString();
        if (Player.Instance.HighScore < (int)score)
        {
            Player.Instance.HighScore = (int)score;
        }
    }
    private void Start()
    {
        score = 0;
        roadScore = 0;
        obstacleScore = 0;
        StartCoroutine(UpdateScoreInSeconds());
        TextMeshPro.text = ((int)score).ToString();
    }

    private void Update()
    {
        if (isGameContinue)
        {
            CalculateScore();
            //TextMeshPro.text = ((int)score).ToString();
        }
    }

    public void SetGameContinue(bool inputBool)
    {
        isGameContinue = inputBool;
    }

    IEnumerator UpdateScoreInSeconds()
    {
        while (true)
        {
            if (isGameContinue)
            {
                yield return new WaitForSeconds(5);
                roadScore += RoadManager.Instance.RoadTreadmill.CurrentSpeed * 100f;
                //TextMeshPro.text = ((int)score).ToString();
            }
        }
    }

    public void AddDamageToObstacleScore(int AnyObstacleScore)
    {
        obstacleScore += AnyObstacleScore * 50;
    }

    public float GetScore()
    {
        return score;
    }

}
