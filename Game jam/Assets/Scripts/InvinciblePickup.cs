using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePickup : MonoBehaviour {

    SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.soundManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundManager.Play(soundManager.collect);
            collision.gameObject.GetComponent<Player>().SetInvincible(5); 
            Destroy(gameObject);
        }
    }
}
