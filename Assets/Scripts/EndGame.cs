using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject EndGameScreen;
    [SerializeField] GameObject NewRecordText;
    [SerializeField] TMP_Text RecordText;
    [SerializeField] TMP_Text ScoreText;

    [Header("Sound Effects")]
    [SerializeField] AudioSource NewRecordAudio;

    private void Awake() => CountDown.OnFinishedTime += HandleEndGame;
    private void OnDestroy() => CountDown.OnFinishedTime -= HandleEndGame;

    void HandleEndGame()
    {
        //Stop the interaction
        ButtonBehaviour.CanInteract = false;
        CountDown.OnFinishedTime -= HandleEndGame;

        int Record = DATA.Load_CountDownRecord();
        int CurrentScore = Score.Current;

        //Activates the "New Record" Text
        EndGameScreen.SetActive(true);
        RecordText.text = Record.ToString();
        ScoreText.text = CurrentScore.ToString();

        HandleScore(Record, CurrentScore);

        FindObjectOfType<Confetti>().PlayConfettis();
    }

    void HandleScore(int currentRecord, int currentScore)
    {
        if (currentRecord > currentScore)
            return;

        NewRecordText.SetActive(true);
        DATA.Save_CountDownRecord(currentScore);
        NewRecordAudio.Play();
        FindObjectOfType<Confetti>().PlayConfettis();
        FindObjectOfType<Confetti>().PlayConfettis();
        FindObjectOfType<Confetti>().PlayConfettis();
    }

}
