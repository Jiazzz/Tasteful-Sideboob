using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    Transform player;
    float speed = 1.5f;
    int health = 15;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if(player == null)
        {
            return;
        }
        Vector3 currentPos = this.transform.position;
        Vector3 targetPos = player.position;

        transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
    }
}
