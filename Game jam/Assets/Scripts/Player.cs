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
    string fireInput;

    [SerializeField]
    Transform barrel;
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float rotSpeed;

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
        if (Input.GetButtonDown(fireInput))
        {
            Shoot();
        }
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
            if(rb.velocity.magnitude<=maxSpeed)
            rb.AddForce(transform.up * speed * yInput);

            float rotateAmount = xInput;
            rb.angularVelocity = -rotateAmount * rotSpeed;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
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
