using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ButtonBehaviour : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] Score score;

    [Header("Button Behaviour")]
    [SerializeField] Transform ButtonTransform;
    [SerializeField] Vector3 IdlePosition;
    [SerializeField] float pressedDepht = 0.2f;

    [Header("Click Audio")]
    public AudioSource OnClickStart;
    public AudioSource OnClickOut;

    public static bool IsClickable { get; set; }
    public static event Action OnButtonDown;
    public static event Action OnButtonUp;


    void Awake()
    {
        IsClickable = true;
        IdlePosition = ButtonTransform.position;

        OnButtonDown += HandleButtonDown;
        OnButtonUp += HandleButtonUp;
    }

    private void OnDestroy()
    {
        OnButtonDown -= HandleButtonDown;
        OnButtonUp -= HandleButtonUp;
    }


    void OnMouseDown()
    {
        if (!IsClickable)
            return;

        OnButtonDown?.Invoke();
    }

    void OnMouseUp()
    {
        if (!IsClickable)
            return;

        OnButtonUp?.Invoke();
    }

    void HandleButtonDown()
    {
        score.IncreaseScore();
        ButtonTransform.position = ButtonTransform.position - (Vector3.up * pressedDepht);
        OnClickStart.Play();
    }

    void HandleButtonUp()
    {
        ButtonTransform.position = IdlePosition;
        OnClickOut.Play();
    }

}

