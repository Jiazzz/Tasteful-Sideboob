using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    float cameraSpeed = 5f;

    [SerializeField]
    float maxZoomDistance = 3;

    [SerializeField]
    float minOrthographic = 1;

    [SerializeField]
    float cameraSmoothTime = 0.3f;
    float zoomValue = 1;

    Camera mainCamera;
    List<GameObject> players;
    float standardOrthographic;
    float newOrthographic;    

	// Use this for initialization
	void Start ()
    {
        mainCamera = this.GetComponent<Camera>();
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if(players.Count == 0)
        {
            Debug.LogError("No players were found");
        }
        standardOrthographic = mainCamera.orthographicSize;
        newOrthographic = standardOrthographic;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        //ScrollUp(cameraSpeed);
        Zoom();
	}

    void ScrollUp(float speed)
    {
        Vector3 newLocation = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        transform.position = newLocation;
    }

    void Zoom()
    {
        if (Vector3.Distance(players[0].transform.position, players[1].transform.position) <= maxZoomDistance)
        {
            zoomValue = ZoomValue();
            mainCamera.orthographicSize = zoomValue * standardOrthographic;

            float AvgX = Average(players[0].transform.position.x, players[1].transform.position.x);
            float AvgY = Average(players[0].transform.position.y, players[1].transform.position.y);

            Vector3 newPosition = new Vector3(AvgX, AvgY, transform.position.z);
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, cameraSmoothTime);

        }
    }

    float ZoomValue()
    {
        return Vector3.Distance(players[0].transform.position, players[1].transform.position) / maxZoomDistance;
    }

    float Average(float a, float b)
    {
        return (a + b) / 2;
    }
}
