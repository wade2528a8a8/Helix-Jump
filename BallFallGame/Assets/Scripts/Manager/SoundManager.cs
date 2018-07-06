using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    private AudioSource audioSource;

    public AudioClip helixBreak;
    public AudioClip ballRebound;
    private void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    private void Play()
    {
        audioSource.Play();
    }

    public void PlayHelixBreak()
    {
        audioSource.clip = helixBreak;
        audioSource.Play();
    }
    public void PlayBallRebound()
    {
        audioSource.clip = ballRebound;
        Play();

    }
}
