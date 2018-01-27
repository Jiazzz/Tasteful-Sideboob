using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    int health = 100;

    [SerializeField]
    int id;

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

    [SerializeField]
    AudioClip shootClip;

    GameManager gameManager;
    SoundManager sm;

    bool canMove;
    bool invincible = false;
    float invincibleTimer;
    float blinkTime = 0.1f;

    Rigidbody2D rb;

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    // Use this for initialization
    void Start () {
        sm = SoundManager.soundManager;
        rb = GetComponent<Rigidbody2D>();
        gameManager = gameManagerObject.GetComponent<GameManager>();
        canMove = true;
	}

    // Update is called once per frame
    void Update() {
        if (otherPlayer != null && Vector2.Distance(otherPlayer.position, transform.position) > gameManager.MaxRange)
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
        if (!invincible && health > 0)
        {
            StartCoroutine(HandleCollision(collision));
        }
        
    }

    IEnumerator HandleCollision(Collision2D collision)
    {
        sm.Play(sm.playerHit);
        //Bounce back
        canMove = false;
        ContactPoint2D contactPoint = collision.contacts[0];
        rb.AddForce(contactPoint.normal * 50);
        yield return new WaitForSeconds(1);
        canMove = true;
        //Animation?

        //Take Damage
        TakeDamage(5);
    }

    IEnumerator HandleInvincibility(int seconds)
    {
        float amount = seconds / blinkTime;
        for (int i = 0; i < amount; i++)
        {
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(blinkTime);
        }
        invincible = false;
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
        sm.Play(shootClip);
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
    }

    void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            gameManager.RespawnPlayer(this.gameObject);
            Destroy(gameObject);
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

    public void SetInvincible(int seconds)
    {
        invincible = true;
        StartCoroutine(HandleInvincibility(seconds));
    }
}
