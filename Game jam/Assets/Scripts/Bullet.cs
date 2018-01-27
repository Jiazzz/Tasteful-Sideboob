using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float speed = 5;
    int lifespan = 2;
    float startTime;

    public SoundManager sm;

    private void Start()
    {
        sm = SoundManager.soundManager;
        startTime = Time.time;
    }

    void Update () {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
        if(Time.time >= startTime + lifespan)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sm.Play(sm.bulletHit);
        Destroy(gameObject);
    }
}
