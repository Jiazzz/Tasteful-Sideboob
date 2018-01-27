using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    static int health = 100;

    [SerializeField]
    float speed;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    string xAxis;
    [SerializeField]
    string yAxis;

    [SerializeField]
    Transform otherPlayer;

    [SerializeField]
    GameObject gameManagerObject;

    GameManager gameManager;

    bool canMove;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameManager = gameManagerObject.GetComponent<GameManager>();
        canMove = true;
	}

    // Update is called once per frame
    void Update() {
        if (Vector2.Distance(otherPlayer.position, transform.position) > gameManager.MaxRange)
        {
            EndGame();
        }
        Move();
	}

    void EndGame()
    {
        canMove = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(HandleCollision(collision));
    }

    IEnumerator HandleCollision(Collision2D collision)
    {
        //Take Damage
        TakeDamage(5);
        //Bounce back
        canMove = false;
        ContactPoint2D contactPoint = collision.contacts[0];
        Debug.Log(contactPoint.normal);
        rb.AddForce(contactPoint.normal * 50);
        yield return new WaitForSeconds(1);
        canMove = true;
        //Animation?
    }


    private void Move()
    {
        float xInput = Input.GetAxisRaw(xAxis);
        float yInput = Input.GetAxisRaw(yAxis);
        Vector2 inputVector = new Vector2(xInput, yInput);
        if (canMove && inputVector != Vector2.zero)
        {
            Vector2 newVelocity = rb.velocity + inputVector * speed;
            if (newVelocity.magnitude <= maxSpeed)
                rb.velocity = newVelocity;
        }
    }

    void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            gameManager.GameOver();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ScreenBounds"))
        {
            ScreenBound screenBound = other.GetComponent<ScreenBound>();
            if(screenBound != null)
            {
                rb.velocity = screenBound.PushInDirection(rb);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
