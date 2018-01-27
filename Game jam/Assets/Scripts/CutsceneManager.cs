using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour {

    [SerializeField]
    Cutscene[] cutscenes;
    int currentCutscene;
    GameObject[] cutsceneImages;
    int currentImage;

    Image image;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        currentCutscene = 0;
    }

    private void OnEnable()
    {
        cutsceneImages = cutscenes[currentCutscene].cutsceneImages;
        currentImage = 0;
        image.sprite = cutsceneImages[currentImage].GetComponent<SpriteRenderer>().sprite;
        image.color = cutsceneImages[currentImage].GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            nextImage();
        }
    }

    void nextImage()
    {
        if (currentImage < cutsceneImages.Length - 1)
        {
            currentImage++;
            image.sprite = cutsceneImages[currentImage].GetComponent<SpriteRenderer>().sprite;
            image.color = cutsceneImages[currentImage].GetComponent<SpriteRenderer>().color;
        }
        else
        {
            EndCutscene();
        }
    }

    void EndCutscene()
    {
        gameObject.SetActive(false);
    }

    public void NextCutscene()
    {
        if (currentCutscene < cutscenes.Length - 1)
        {
            currentCutscene++;
        }
    }
}
