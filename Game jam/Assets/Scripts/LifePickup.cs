using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour {

    GameManager gameManager;
    SoundManager soundManager;

    private void Start()
    {
        gameManager = GameManager.gameManager;
        soundManager = SoundManager.soundManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundManager.Play(soundManager.collect);
            gameManager.IncreaseLife();
            Destroy(gameObject);
        }
    }
}
