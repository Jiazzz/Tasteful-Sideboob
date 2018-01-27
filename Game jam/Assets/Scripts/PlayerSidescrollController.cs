using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSidescrollController : MonoBehaviour {

    float speed = 5f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.position;
        newPos.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        transform.position = newPos;
	}
}
