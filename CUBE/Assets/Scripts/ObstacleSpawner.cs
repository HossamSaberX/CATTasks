using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public float baseSpawnInterval = 1f;
    public float spawnZ = 50f;
    public float minX = -5f;
    public float maxX = 5f;
    public float difficultyFactor = 0.001f; 
    public float obstacleLifetime = 5;

    void Start()
    {
        StartCoroutine(SpawnObstacleCoroutine());
    }

    IEnumerator SpawnObstacleCoroutine()
    {
        while (true)
        {
            SpawnObstacle();
            float difficultyMultiplier = 1 + (player.position.z * difficultyFactor);
            float currentInterval = Mathf.Max(0.1f, baseSpawnInterval / difficultyMultiplier);
            yield return new WaitForSeconds(currentInterval);
        }
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, 0, player.position.z + spawnZ);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        float randomScale = Random.Range(0.5f, 5f);
        obstacle.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        obstacle.transform.rotation = Random.rotation;
        Destroy(obstacle, obstacleLifetime);
    }
}
