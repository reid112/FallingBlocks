using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text currentScoreValueText;
    public Text highScoreValueText;
    public Text gameScore;

    PlayerController playerController;

    int currentScore = 0;
    bool isGameOver;
    
    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
        playerController.OnPlayerDeath += OnGameOver;
        playerController.OnCoinCollected += OnCoinCollected;
    }

    void Update()
    {
        if (isGameOver) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnGameOver() {
        gameOverScreen.SetActive(true);
        currentScoreValueText.text = "5"; // TODO
        highScoreValueText.text = "10"; // TODO
        isGameOver = true;
    }

    private void OnCoinCollected() {
        currentScore++;
        gameScore.text = currentScore.ToString();
    }
}
