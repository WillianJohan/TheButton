using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int CurrentScore { get; private set; } = 0;
    [SerializeField] TMP_Text CurrentScoreText;

    void Start()
    {
        CurrentScore = 0;
        CurrentScoreText.text = CurrentScore.ToString();
    }

    public void IncreaseScore()
    {
        CurrentScore++;
        CurrentScoreText.text = CurrentScore.ToString();
    }

}
