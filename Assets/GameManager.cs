using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Spawning")]
    [Tooltip("Drag your obstacle prefab here")]
    public GameObject obstaclePrefab;

    [Tooltip("Drag an empty GameObject here to mark the spawn location")]
    public Transform spawnPoint;

    private float fixedX;

    void Start()
    {
        // Cache the correct X position from the spawnPoint
        fixedX = spawnPoint.position.x;

        // Start spawning obstacles
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Wait randomly between 1.5 and 5 seconds
            float waitTime = Random.Range(0.7f, 5f);
            yield return new WaitForSeconds(waitTime);

            // Get the spawn position and lock X
            Vector3 spawnPos = spawnPoint.position;
            spawnPos.x = fixedX;

            // Instantiate the obstacle at fixed X position
            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        }
    }
}
