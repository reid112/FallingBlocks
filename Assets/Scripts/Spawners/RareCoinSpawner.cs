using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareCoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Vector2 spawnSize;
    public float secondsBetweenSpawnChance;
    public float spawnChance;

    Vector2 halfScreenDimensionsInWorldUnits;
    float nextSpawnChanceTime;

    void Start()
    {
        float orthoSize = Camera.main.orthographicSize;
        halfScreenDimensionsInWorldUnits = new Vector2(Camera.main.aspect * orthoSize, orthoSize);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnChanceTime) {
            nextSpawnChanceTime = Time.timeSinceLevelLoad + secondsBetweenSpawnChance;
            
            if (Random.value < spawnChance) {
                float spawnPositionX = Random.Range(-halfScreenDimensionsInWorldUnits.x, halfScreenDimensionsInWorldUnits.x);
                float spawnPositionY = halfScreenDimensionsInWorldUnits.y + spawnSize.y;

                Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);
                
                GameObject spawnedCoin = (GameObject) Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

                spawnedCoin.transform.localScale = new Vector2(spawnSize.x, spawnSize.y);
            }
        }
    }   
}
