using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float minSecondsBetweenSpawns;
    public float maxSecondsBetweenSpawns;
    public GameObject[] powerUpPrefabs;
    public Vector2 spawnSize;
    
    float nextSpawnTime;
    GameObject nextSpawnPowerUp;
    Vector2 halfScreenDimensionsInWorldUnits;

    void Start()
    {
        float orthoSize = Camera.main.orthographicSize;
        halfScreenDimensionsInWorldUnits = new Vector2(Camera.main.aspect * orthoSize, orthoSize);
        nextSpawnTime = Random.Range(minSecondsBetweenSpawns, maxSecondsBetweenSpawns);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime) {
            nextSpawnPowerUp = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];
            nextSpawnTime = Time.timeSinceLevelLoad + Random.Range(minSecondsBetweenSpawns, maxSecondsBetweenSpawns);
            
            float spawnPositionX = Random.Range(-halfScreenDimensionsInWorldUnits.x, halfScreenDimensionsInWorldUnits.x);
            float spawnPositionY = halfScreenDimensionsInWorldUnits.y + spawnSize.y;

            Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);
            
            GameObject spawnedPowerUp = (GameObject) Instantiate(nextSpawnPowerUp, spawnPosition, Quaternion.identity);

            spawnedPowerUp.transform.localScale = new Vector2(spawnSize.x, spawnSize.y);
        }
    }   
}