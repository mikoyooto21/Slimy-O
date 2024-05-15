using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float initialSpawnInterval = 2f; // Початковий інтервал спавну
    public float obstacleSpeed = 5f;
    public float obstacleHeight = 2f;
    public float intervalDecrement = 0.1f; // Зменшення інтервалу з кожним спавном
    public float minSpawnInterval = 1.3f; // Мінімальний інтервал спавну

    private float nextSpawnTime = 0f;
    private float currentSpawnInterval; // Поточний інтервал спавну

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + currentSpawnInterval;

            // Зменшуємо інтервал
            currentSpawnInterval = Mathf.Max(currentSpawnInterval - intervalDecrement, minSpawnInterval);
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + 10f, Random.Range(-3.35f, -2f), 0f);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D obstacleRb = obstacle.GetComponent<Rigidbody2D>();

        if (obstacleRb != null)
        {
            obstacleRb.velocity = new Vector2(-obstacleSpeed, 0f);
        }
    }
}
