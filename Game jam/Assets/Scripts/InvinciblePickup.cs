using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePickup : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().SetInvincible(5);
            Destroy(gameObject);
        }
    }
}
