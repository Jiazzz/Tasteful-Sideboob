using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float cameraSpeed = 5f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ScrollUp(cameraSpeed);
	}

    private void ScrollUp(float speed)
    {
        Vector3 newLocation = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        transform.position = newLocation;
    }
}
