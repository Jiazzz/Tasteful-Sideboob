using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    float cameraSpeed = 5f;

    [SerializeField]
    bool scroll = false;

    List<GameObject> players;

	// Use this for initialization
	void Start ()
    {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if(players.Count == 0)
        {
            Debug.LogError("No players were found");
        }
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (scroll)
        {
            ScrollUp(cameraSpeed);
        }
	}

    void ScrollUp(float speed)
    {
        Vector3 newLocation = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        transform.position = newLocation;
    }
}
