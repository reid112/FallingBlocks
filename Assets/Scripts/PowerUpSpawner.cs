using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float minSecondsBetweenSpawns;
    public float maxSecondsBetweenSpawns;
    public GameObject speedPowerUpPrefab;
    public Vector2 spawnSize;
    
    float nextSpawnTime;
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
            nextSpawnTime = Time.timeSinceLevelLoad + Random.Range(minSecondsBetweenSpawns, maxSecondsBetweenSpawns);
            
            float spawnPositionX = Random.Range(-halfScreenDimensionsInWorldUnits.x, halfScreenDimensionsInWorldUnits.x);
            float spawnPositionY = halfScreenDimensionsInWorldUnits.y + spawnSize.y;

            Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);
            
            GameObject spawnedPowerUp = (GameObject) Instantiate(speedPowerUpPrefab, spawnPosition, Quaternion.identity);

            spawnedPowerUp.transform.localScale = new Vector2(spawnSize.x, spawnSize.y);
        }
    }   
}