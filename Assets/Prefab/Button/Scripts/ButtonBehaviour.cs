using System;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [Header("Score Point")]
    [SerializeField] InGameScore score;

    [Header("Button Position")]
    [SerializeField] Transform ButtonTransform;
    [SerializeField] Vector3 IdlePosition;
    [SerializeField] float pressedDepht = 0.2f;
    
    [Header("Click Audio")]
    public AudioSource OnClickStart;
    public AudioSource OnClickOut;

    public static event Action OnButtonDown;
    public static event Action OnButtonUp;

    public static bool CanInteract = true;


    private void Start()
    {
        IdlePosition = ButtonTransform.position;
        
        OnButtonDown += HandleButtonDown;
        OnButtonUp += HandleButtonUp;
    }

    void OnDestroy()
    {
        OnButtonDown -= HandleButtonDown;
        OnButtonUp -= HandleButtonUp;
    }

    void OnMouseDown()
    {
        if (!CanInteract)
            return;

        OnButtonDown?.Invoke();
    }
    void OnMouseUp()
    {
        if (!CanInteract && ButtonTransform.position == IdlePosition)
            return;

        OnButtonUp?.Invoke();
    }


    void HandleButtonDown()
    {
        score.IncreaseScore();
        ButtonTransform.position = ButtonTransform.position - Vector3.up * pressedDepht;
        OnClickStart.Play();
    }

    void HandleButtonUp()
    {
        ButtonTransform.position = IdlePosition;
        OnClickOut.Play();
    }

}
