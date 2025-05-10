using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Game: MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnPoint;
    public GameObject startButton; // Assign the UI button here in Inspector

    private bool gameStarted = false;

    void Start()
    {
        Time.timeScale = 0f; // Pause the game initially
        startButton.SetActive(true); // Show the Start button
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // Resume the game
        startButton.SetActive(false); // Hide the button
        gameStarted = true;

        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (gameStarted)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 2f));
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 0f; // Pause the game again
        gameStarted = false;

        // Destroy all obstacles
        foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Destroy(obstacle);
        }

        startButton.SetActive(true); // Show the start button again
    }
}
