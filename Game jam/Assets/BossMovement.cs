using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    float speed = -7f;
    float boundary = 5;
    float turnSpeed = 0.5f;
    float rotation = 180;

    float shootTimer;

    float minShootTimer = 0.8f;
    float maxShootTimer = 1.2f;

    float widthLeft = 2f;
    float widthRight = 3f;

    [SerializeField]
    GameObject bullet;

	// Use this for initialization
	void Start () {
        shootTimer = Random.Range(minShootTimer, maxShootTimer);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = this.transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if((pos.x >= boundary && speed > 0) || (pos.x <= -boundary && speed < 0))
        {
            //StartCoroutine("TurnAround()");

            speed = -speed;
            Vector3 rot = new Vector3(0, rotation);
            Vector3 currentRot = transform.rotation.eulerAngles;
            this.transform.rotation = Quaternion.Euler(currentRot - rot);
        }

        shootTimer -= Time.deltaTime;
        if(shootTimer <= 0)
        {
            Shoot();
            shootTimer = Random.Range(minShootTimer, maxShootTimer);
        }

	}
    /*
    private IEnumerator TurnAround()
    {
        transform.Rotate(Vector3.up, turnSpeed);
    }*/

    void Shoot()
    {
        Vector3 shootPos = new Vector3(transform.position.x - Random.Range(-widthLeft, widthRight), this.transform.position.y);
        Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, 180));
    }
}
