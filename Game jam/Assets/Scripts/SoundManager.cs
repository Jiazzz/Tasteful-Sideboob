using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    public AudioClip bulletHit;
    [SerializeField]
    public AudioClip playerHit;
    [SerializeField]
    AudioSource source;

    public static SoundManager soundManager;

    private void Awake()
    {
        soundManager = this;
    }

    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

}
