using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    string xAxis;
    [SerializeField]
    string yAxis;

    [SerializeField]
    float maxRange;

    [SerializeField]
    Transform otherPlayer;

    bool canMove;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
	}

    // Update is called once per frame
    void Update() {
        if (Vector2.Distance(otherPlayer.position, transform.position) > maxRange)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Take damage
        Debug.Log("Damage");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(HandleCollision(collision));
    }

    IEnumerator HandleCollision(Collision2D collision)
    {
        //Take damage
        //Bounce back
        canMove = false;
        ContactPoint2D contactPoint = collision.contacts[0];
        Debug.Log(contactPoint.normal);
        rb.AddForce(contactPoint.normal * 50);
        yield return new WaitForSeconds(2);
        canMove = true;
        //Animation?
        Debug.Log("Damage");
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
}
