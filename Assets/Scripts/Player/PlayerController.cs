using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event System.Action<GameObject> OnHitByBlock;
    public event System.Action OnCoinCollected;
    public event System.Action OnRareCoinCollected;
    public event System.Action OnSuperSpeedStart;
    public event System.Action OnSuperSpeedEnd;
    public event System.Action OnLifeCollected;
    
    public float speed = 7;
    public float superSpeed = 14;
    public float superSpeedTime = 5;
    public float playerPositionFromBottom = 0.3f;

    float halfScreenWithInWorldUnits;
    float superSpeedTimeRemaining;
    bool isSuperSpeed;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        float halfPlayerWidthInWorldUnits = transform.localScale.x / 2f;
        halfScreenWithInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidthInWorldUnits;
    }

    void Update()
    {
        // Keyboard input
        float inputX = Input.GetAxisRaw(Constants.HORIZONTAL);
    
        // Touch input
        foreach (Touch touch in Input.touches) {
            if (touch.position.x < Screen.width/2) {
                inputX = Constants.LEFT;
            } else {
                inputX = Constants.RIGHT;
            }
        }

        // Set speed and/or super speed
        float velocity = inputX * speed;
        if (isSuperSpeed) {
            velocity = inputX * superSpeed;
        } 
    
        // Move
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        // Wrap player around screen
        if (transform.position.x < -halfScreenWithInWorldUnits) {
            transform.position = new Vector2(halfScreenWithInWorldUnits, transform.position.y);
        } else if (transform.position.x > halfScreenWithInWorldUnits) {
            transform.position = new Vector2(-halfScreenWithInWorldUnits, transform.position.y);
        }

        // Set ufo flames animation direction
        animator.SetInteger(Constants.ANIMATOR_ROTATION_DIRECTION, (int) inputX);

        // Calculate superspeed
        if (superSpeedTimeRemaining > 0) {
            superSpeedTimeRemaining -= Time.deltaTime;
        } else {
            isSuperSpeed = false;
            OnSuperSpeedEnd?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider) {
        if (triggerCollider.tag == Constants.TAG_FALLING_BLOCK) {
            OnHitByBlock?.Invoke(triggerCollider.gameObject);
        } else if (triggerCollider.tag == Constants.TAG_COIN) {
            OnCoinCollected?.Invoke();
            Destroy(triggerCollider.gameObject);
        } else if (triggerCollider.tag == Constants.TAG_RARE_COIN) {
            OnRareCoinCollected?.Invoke();
            Destroy(triggerCollider.gameObject);
        } else if (triggerCollider.tag == Constants.TAG_POWER_UP_SPEED) {
            isSuperSpeed = true;
            superSpeedTimeRemaining = superSpeedTime;
            OnSuperSpeedStart?.Invoke();
            Destroy(triggerCollider.gameObject);
        } else if (triggerCollider.tag == Constants.TAG_POWER_UP_LIFE) {
            OnLifeCollected?.Invoke();
            Destroy(triggerCollider.gameObject);
        }
    }
}
