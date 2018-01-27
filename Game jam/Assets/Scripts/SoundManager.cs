using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    public AudioClip backgroundMusic;
    [SerializeField]
    public AudioClip bulletHit;
    [SerializeField]
    public AudioClip playerHit;
    [SerializeField]
    public AudioClip collect;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioSource loopingSource;

    public static SoundManager soundManager;

    private void Awake()
    {
        soundManager = this;
    }

    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void Loop(AudioClip clip)
    {
        loopingSource.PlayOneShot(clip);
    }

}
