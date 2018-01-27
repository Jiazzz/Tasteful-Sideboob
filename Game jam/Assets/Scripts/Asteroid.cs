using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    float speed = 2;
	int damage = 20; 
	int hp = 40; 
	
	[SerializeField]
    GameObject subAsteroidPrefab;
	
	//TODO: collision with bullet, hp -= amount


	// Update is called once per frame
    void Update() {
        if (hp <= 0)
        {
            Break();
        }
	}
	
	void LateUpdate () {
        transform.Translate(transform.down * speed * Time.deltaTime);
	}
	
	void Break()
    {
        bool diag = rand.NextDouble() > 0.5;
		EjectAsteroid(diag, 0);
		EjectAsteroid(diag, 90);
		EjectAsteroid(diag, 180);
		EjectAsteroid(diag, 270);
    }
	
	void EjectAsteroid(bool diag, int angle)
	{
		GameObject subAsteroid = Instantiate(subAsteroidPrefab, transform.position, Quaternion.eulerAngles(angle + diag * 45));
	}

    
}
