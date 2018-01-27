using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float speed = 5;

    public SoundManager sm;

    private void Start()
    {
        sm = SoundManager.soundManager;
    }

    void Update () {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sm.Play(sm.bulletHit);
        Destroy(gameObject);
    }
}
