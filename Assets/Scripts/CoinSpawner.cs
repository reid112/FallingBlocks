using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
 public GameObject coinPrefab;
    public float secondsBetweenSpawns;
    float nextSpawnTime;
    Vector2 halfScreenDimensionsInWorldUnits;
    public Vector2 spawnSize;

    void Start()
    {
        float orthoSize = Camera.main.orthographicSize;
        halfScreenDimensionsInWorldUnits = new Vector2(Camera.main.aspect * orthoSize, orthoSize);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime) {
            nextSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSpawns;
            
            float spawnPositionX = Random.Range(-halfScreenDimensionsInWorldUnits.x, halfScreenDimensionsInWorldUnits.x);
            float spawnPositionY = halfScreenDimensionsInWorldUnits.y + spawnSize.y;

            Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);
            
            GameObject spawnedBlock = (GameObject) Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            spawnedBlock.transform.localScale = new Vector2(spawnSize.x, spawnSize.y);
        }
    }   
}
