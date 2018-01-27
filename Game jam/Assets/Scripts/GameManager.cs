using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    float maxRange;
    [SerializeField]
    int respawnInvincibilityTime = 2;

    List<GameObject> players;
    int[] playerLives;

    Camera mainCamera;

    void Start()
    {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if(players.Count == 0)
        {
            Debug.LogError("No players were found.");
        }
        playerLives = new int[players.Count];
        for (int i = 0; i < playerLives.Length; i++)
        {
            playerLives[i] = 3;
        } 
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        
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

    public void RespawnPlayer(GameObject go, int id)
    {
        GameObject spawnedPlayer = Instantiate(go, new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y), Quaternion.identity);
        spawnedPlayer.GetComponent<Player>().SetInvincible(respawnInvincibilityTime);
        playerLives[id]--;
        if (playerLives[id]<=0)
        {
            //TODO: Animate or something I don't know, not creative
            GameOver();
        }
    }
}
