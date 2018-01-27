using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    float speed = 2;
	int damage = 20; 
	
	[SerializeField]
    GameObject subAsteroidPrefab;


	// Update is called once per frame
    void Update() {
        if (Input.GetButtonDown(fireInput))
        {
            Break();
        }
	}
	
	void LateUpdate () {
        transform.Translate(transform.down * speed * Time.deltaTime);
	}
	
	void Break()
    {
        bool diag = rand.NextDouble();
		EjectAsteroid(diag, 0);
		EjectAsteroid(diag, 90);
		EjectAsteroid(diag, 180);
		EjectAsteroid(diag, 270);
    }
	
	void EjectAsteroid(bool diag, int angle)
	{
		GameObject subAsteroid = Instantiate(subAsteroidPrefab, transform.position, (angle + diag * 45));
	}

    
}
