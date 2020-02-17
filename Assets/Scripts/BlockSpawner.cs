using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public float secondsBetweenSpawnsMin;
    public float secondsBetweenSpawnsMax;
    float nextSpawnTime;
    Vector2 halfScreenDimensionsInWorldUnits;
    public Vector2 spawnSizeMin;
    public Vector2 spawnSizeMax;
    public float spawnAngleMax;

    void Start()
    {
        float orthoSize = Camera.main.orthographicSize;
        halfScreenDimensionsInWorldUnits = new Vector2(Camera.main.aspect * orthoSize, orthoSize);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime) {

            nextSpawnTime = Time.timeSinceLevelLoad + Mathf.Lerp(secondsBetweenSpawnsMax, secondsBetweenSpawnsMin, DifficultyManager.GetDifficultyPercent());

            float spawnSizeX = Random.Range(spawnSizeMin.x, spawnSizeMax.x);
            float spawnSizeY = Random.Range(spawnSizeMin.y, spawnSizeMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnPositionX = Random.Range(-halfScreenDimensionsInWorldUnits.x, halfScreenDimensionsInWorldUnits.x);
            float spawnPositionY = halfScreenDimensionsInWorldUnits.y + spawnSizeY;

            Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);
            
            GameObject spawnedBlock = (GameObject) Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

            spawnedBlock.transform.localScale = new Vector2(spawnSizeX, spawnSizeY);
        }
    }
}
