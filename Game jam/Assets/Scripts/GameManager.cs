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

    Camera mainCamera;

    void Start()
    {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if(players.Count == 0)
        {
            Debug.LogError("No players were found.");
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

    void RespawnPlayer(GameObject go)
    {
        GameObject spawnedPlayer = Instantiate(go, new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y), Quaternion.identity);
        spawnedPlayer.GetComponent<Player>().SetInvincible(respawnInvincibilityTime);
    }
}
