using TMPro;
using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject ClicksPanel;
    [SerializeField] GameObject TimerPanel;

    [Header("End Game UI Elements")]
    [SerializeField] GameObject EndGamePanel;
    [SerializeField] TMP_Text Header;
    [SerializeField] TMP_Text RecordCountText;
    [SerializeField] TMP_Text ClicksCountText;

    [Header("Sound Effects")]
    [SerializeField] AudioSource NewRecordAudio;
    
    [Header("Game Mode")]
    [SerializeField] PlayerDATA.GameMode mode;
    

    
    private void Awake()     => CountDown.OnFinishedTime += HandleEndGame;
    private void OnDestroy() => CountDown.OnFinishedTime -= HandleEndGame;




    void HandleEndGame()
    {
        //Stop the interaction
        CountDown.OnFinishedTime -= HandleEndGame;
        ButtonBehaviour.IsClickable = false;

        int oldRecord = PlayerDATA.Load(mode);
        int currentClicks = Score.CurrentScore;

        SetUIValues(currentClicks, oldRecord);
        ActivateEndGameInterface();

        FindObjectOfType<Confetti>().PlayConfettis();
    }

    void ActivateEndGameInterface()
    {
        // Desactivate the runtime UI
        ClicksPanel.SetActive(false);
        TimerPanel.SetActive(false);

        //Activate the EndGamePanel
        EndGamePanel.SetActive(true);
    }

    void SetUIValues(int currentClicks, int oldRecord)
    {
        //Set the values in the end game panel
        RecordCountText.text = oldRecord.ToString();
        ClicksCountText.text = currentClicks.ToString();

        //Set the text to the Header in the end Game panel
        if (currentClicks < oldRecord)
            Header.text = "Game Over";
        else
        {
            Header.text = "New Record!!";
            PlayerDATA.Save(mode, currentClicks);
            NewRecordAudio.Play();
        }
    }

}
