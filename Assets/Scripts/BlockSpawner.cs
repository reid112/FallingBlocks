﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public float secondsBetweenSpawnsMin;
    public float secondsBetweenSpawnsMax;
    public float spawnAngleMax;
    public float spawnSizeMin;
    public float spawnSizeMax;
    public GameObject fallingBlockPrefab;

    float nextSpawnTime;
    Vector2 halfScreenDimensionsInWorldUnits;

    void Start()
    {
        float orthoSize = Camera.main.orthographicSize;
        halfScreenDimensionsInWorldUnits = new Vector2(Camera.main.aspect * orthoSize, orthoSize);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime) {

            nextSpawnTime = Time.timeSinceLevelLoad + Mathf.Lerp(secondsBetweenSpawnsMax, secondsBetweenSpawnsMin, DifficultyManager.GetDifficultyPercent());

            float spawnSize = Random.Range(spawnSizeMin, spawnSizeMax);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnPositionX = Random.Range(-halfScreenDimensionsInWorldUnits.x, halfScreenDimensionsInWorldUnits.x);
            float spawnPositionY = halfScreenDimensionsInWorldUnits.y + spawnSize;

            Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);
            
            GameObject spawnedBlock = (GameObject) Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

            spawnedBlock.transform.localScale = new Vector2(spawnSize, spawnSize);
        }
    }
}
