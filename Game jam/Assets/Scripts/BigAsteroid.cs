using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : Asteroid {

    [SerializeField]
    GameObject subAsteroidPrefab;

    protected override void Break()
    {
        EjectAsteroid(0);
        EjectAsteroid(90);
        EjectAsteroid(180);
        EjectAsteroid(270);
        Destroy(gameObject);
    }

    void EjectAsteroid(int angle)
    {
        Quaternion rotation = Quaternion.identity;
        float factor = Random.Range(0, 5);
        rotation.eulerAngles = new Vector3(0, 0, angle + factor/5 * 45);
        GameObject subAsteroid = Instantiate(subAsteroidPrefab, transform.position, rotation);
    }
}
