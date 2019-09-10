using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip sound;

    public AudioSource soundSource;

    void Start()
    {
        soundSource.clip = sound;
        soundSource.Play();
    }
}
