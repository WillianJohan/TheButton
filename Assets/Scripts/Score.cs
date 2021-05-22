using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int Current { get; private set; } = 0;
    [SerializeField] TMP_Text CurrentScoreText;

    

    void Start()
    {
        Current = 0;
        CurrentScoreText.text = Current.ToString();
    }

    public void IncreaseScore()
    {
        Current++;
        CurrentScoreText.text = Current.ToString();
    }

}
