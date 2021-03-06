﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    float maxRange;
    [SerializeField]
    int respawnInvincibilityTime = 2;

    [SerializeField]
    List<GameObject> players;
    int playerLives;

    [SerializeField]
    Text hp1Text, hp2Text, livesText;



    Camera mainCamera;

    public static GameManager gameManager;

    SoundManager soundManager;

    private void Awake()
    {
        gameManager = this;
    }

    void Start()
    {
        soundManager = SoundManager.soundManager;
        if(players.Count == 0)
        {
            Debug.LogError("No players were found.");
        }
        playerLives = 3;
        mainCamera = FindObjectOfType<Camera>();
        SetHP1Text();
        SetHP2Text();
        soundManager.Loop(soundManager.backgroundMusic);
    }

    private void Update()
    {
        livesText.text = playerLives.ToString();
        SetHP1Text();
        SetHP2Text();
    }

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

    public void IncreaseLife()
    {
        playerLives++;
    }

    public void RespawnPlayer(GameObject go, int id)
    {
        GameObject spawnedPlayer = Instantiate(go, new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y), Quaternion.identity);
        spawnedPlayer.GetComponent<Player>().SetInvincible(respawnInvincibilityTime);
        players[id] = spawnedPlayer;
        playerLives--;
        if (playerLives<=0)
        {
            //TODO: Animate or something I don't know, not creative
            GameOver();
        }
    }

    public void SetHP1Text()
    {
        hp1Text.text = "Player 1: " + players[0].GetComponent<Player>().Health + "/100";
    }

    public void SetHP2Text()
    {
        hp2Text.text = "Player 2: " + players[1].GetComponent<Player>().Health + "/100";
    }


}
