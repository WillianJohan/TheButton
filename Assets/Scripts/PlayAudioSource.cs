using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSource : MonoBehaviour
{
    [SerializeField] float Delay;
    [SerializeField] AudioSource[] sources;

    void Start()
    {
        foreach (AudioSource audio in sources)
            audio.Play((ulong)(44100*Delay));
    }

}
