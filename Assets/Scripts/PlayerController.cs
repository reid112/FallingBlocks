﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;
    public float playerPositionFromBottom = 0.3f;
    float halfScreenWithInWorldUnits;
    float halfPlayerWidthInWorldUnits;
    float halfPlayerHeightInWorldUnits;

    Animator animator;

    public event System.Action OnPlayerDeath;
    public event System.Action OnCoinCollected;

    void Start()
    {
        animator = GetComponent<Animator>();

        halfPlayerWidthInWorldUnits = transform.localScale.x / 2f;
        halfPlayerHeightInWorldUnits = transform.localScale.y / 2f;
        halfScreenWithInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidthInWorldUnits;

        transform.position = new Vector2(0, -5 + halfPlayerHeightInWorldUnits + playerPositionFromBottom);
    }

    void Update()
    {
        // Keyboard input
        float inputX = Input.GetAxisRaw("Horizontal");
    
        // Touch input
        foreach (Touch touch in Input.touches) {
            if (touch.position.x < Screen.width/2) {
                inputX = -1;
            } else {
                inputX = 1;
            }
        }

        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -halfScreenWithInWorldUnits) {
            transform.position = new Vector2(halfScreenWithInWorldUnits, transform.position.y);
        } else if (transform.position.x > halfScreenWithInWorldUnits) {
            transform.position = new Vector2(-halfScreenWithInWorldUnits, transform.position.y);
        }

        animator.SetInteger("Direction", (int) inputX);
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider) {
        if (triggerCollider.tag == "Falling Block") {
            OnPlayerDeath?.Invoke();
            Destroy(gameObject);
        } else if (triggerCollider.tag == "Coin") {
            OnCoinCollected?.Invoke();
            Destroy(triggerCollider.gameObject);
        }
    }
}
