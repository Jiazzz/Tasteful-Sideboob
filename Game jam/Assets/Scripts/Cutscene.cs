using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour {

    [SerializeField]
    GameObject[] cutsceneImages;
    int currentImage;

	// Use this for initialization
	void Start () {
        currentImage = 0;
        foreach (GameObject image in cutsceneImages)
        {
            image.GetComponent<SpriteRenderer>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i <= currentImage; i++)
        {
            cutsceneImages[i].GetComponent<SpriteRenderer>().enabled = true;
        }
	}

    void nextImage()
    {
        if (currentImage < cutsceneImages.Length - 1)
        {
            currentImage++;
        }
    }
}
