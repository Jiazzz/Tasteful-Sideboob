﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    float maxRange;

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadLevel(string text)
    {
        SceneManager.LoadScene(text);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        LoadLevel("GameOver");
    }

    public float MaxRange
    {
        get { return maxRange; }
        set { maxRange = value; }
    }

}
