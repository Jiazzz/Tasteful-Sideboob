using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float cameraSpeed = 5f;
    private Camera mainCamera;
    private ArrayList players;

	// Use this for initialization
	void Start ()
    {
        mainCamera = this.GetComponent<Camera>();
        players = new ArrayList(GameObject.FindGameObjectsWithTag("Player"));
	}
	
	// Update is called once per frame
	void Update ()
    {


        //ScrollUp(cameraSpeed);
	}

    private void ScrollUp(float speed)
    {
        Vector3 newLocation = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        transform.position = newLocation;
    }
}
