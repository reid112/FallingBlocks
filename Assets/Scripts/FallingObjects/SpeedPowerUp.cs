﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    
    Vector2 halfScreenDimensionsInWorldUnits;

    void Start() {
        float orthoSize = Camera.main.orthographicSize;
        halfScreenDimensionsInWorldUnits = new Vector2(Camera.main.aspect * orthoSize, orthoSize);    
    }

    void Update()
    {
        float speed = Random.Range(minSpeed, maxSpeed);
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -halfScreenDimensionsInWorldUnits.y - transform.localScale.y) {
            Destroy(gameObject);
        }
    }
}
