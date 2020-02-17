using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource musicAudio;
    public AudioSource gameOverAudio;
    public AudioSource coinAudio;
    public GameObject gameOverScreen;
    public Text currentScoreValueText;
    public Text highScoreValueText;
    public Text gameScore;

    PlayerController playerController;

    int currentScore = 0;
    int highScore = 0;
    bool isGameOver;
    
    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
        playerController.OnPlayerDeath += OnGameOver;
        playerController.OnCoinCollected += OnCoinCollected;

        highScore = PlayerPrefs.GetInt(Constants.HIGH_SCORE_KEY, 0);
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
        if (currentScore > highScore) {
            highScore = currentScore;
            PlayerPrefs.SetInt(Constants.HIGH_SCORE_KEY, highScore);
        }
        
        gameOverScreen.SetActive(true);
        currentScoreValueText.text = currentScore.ToString();
        highScoreValueText.text = highScore.ToString();
        isGameOver = true;

        musicAudio.Stop();
        gameOverAudio.Play();
    }

    private void OnCoinCollected() {
        currentScore++;
        gameScore.text = currentScore.ToString();

        coinAudio.Play();
    }
}
