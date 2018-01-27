using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour {

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.gameManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.IncreaseLife();
            Destroy(gameObject);
        }
    }
}
