using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
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
        float speed = Mathf.Lerp(minSpeed, maxSpeed, DifficultyManager.GetDifficultyPercent());
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -halfScreenDimensionsInWorldUnits.y - transform.localScale.y) {
            Destroy(gameObject);
        }
    }
}
