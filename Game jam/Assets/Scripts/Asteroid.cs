using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField]
    protected float speed = 2;
    [SerializeField]
	protected int damage = 20; 
    [SerializeField]
	protected int hp = 40; 
	
	// Update is called once per frame
    void Update() {
        if (hp <= 0)
        {
            Break();
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        TakeDamage(10);
    }

    void LateUpdate () {
        transform.Translate(transform.up * -speed * Time.deltaTime, Space.World);
	}
	

    void TakeDamage(int amount)
    {
        hp -= amount;
    }

    protected virtual void Break()
    {
        Destroy(gameObject);
    }
 
}
