using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Player player;
    private GameManager gameManager;
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpeed = 1f;
    public float obstacleSpawnTime = 2f;
    private float timeUntilObstacleSpawn;
    private void Start()
    {
        gameManager = FindObjectOfType< GameManager>();
    }
    private void Update()
    {
        if (gameManager.isPlaying)
        {
            SpawnLoop();
        }
    }
    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;
        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }
    private void Spawn()
    {
        GameObject obstcaleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject spawnedObstable = Instantiate(obstcaleToSpawn,transform.position,Quaternion.identity);
        Rigidbody2D obstacleRB = spawnedObstable.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
        Destroy(spawnedObstable, player.speed);
    }
}
