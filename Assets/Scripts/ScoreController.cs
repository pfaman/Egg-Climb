using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoSingleton<ScoreController>
{
    private int score = 0;
    public bool scoreIT;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI ResultScreenscoreText;

    private void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int increment)
    {
        if(scoreIT)
        {
            score += increment;
            RefreshUI();
        }
    }

    private void RefreshUI()
    {
        scoreText.text = "Score : " + score;
        ResultScreenscoreText.text = scoreText.text;
    }
}
