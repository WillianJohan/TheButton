using TMPro;
using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject EndGameScreen;
    [SerializeField] GameObject NewRecordText;
    [SerializeField] TMP_Text RecordText;
    [SerializeField] TMP_Text ScoreText;

    [Header("Sound Effects")]
    [SerializeField] AudioSource NewRecordAudio;

    
    [Header("Game Mode")]
    [SerializeField] PlayerDATA.GameMode mode;
    
    
    private void Awake()     => CountDown.OnFinishedTime += HandleEndGame;
    private void OnDestroy() => CountDown.OnFinishedTime -= HandleEndGame;




    void HandleEndGame()
    {
        //Stop the interaction
        ButtonBehaviour.IsClickable = false;
        CountDown.OnFinishedTime -= HandleEndGame;

        int Record = PlayerDATA.Load(mode);
        int CurrentScore = Score.CurrentScore;

        //Activates the "New Record" Text
        EndGameScreen.SetActive(true);
        RecordText.text = Record.ToString();
        ScoreText.text = CurrentScore.ToString();

        HandleScore(Record, CurrentScore);

        //FindObjectOfType<Confetti>().PlayConfettis();
    }

    void HandleScore(int currentRecord, int currentScore)
    {
        if (currentRecord > currentScore)
            return;

        NewRecordText.SetActive(true);
        PlayerDATA.Save(mode, currentScore);
        NewRecordAudio.Play();
        //FindObjectOfType<Confetti>().PlayConfettis();
    }
}
