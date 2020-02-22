using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource musicAudio;
    public AudioSource gameOverAudio;
    public AudioSource coinAudio;
    public AudioSource speedAudio;
    public GameObject gameOverScreen;
    public Text currentScoreValueText;
    public Text highScoreValueText;
    public Text gameScore;

    int currentScore = 0;
    int highScore = 0;

    PlayerController playerController;
    
    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
        playerController.OnPlayerDeath += OnGameOver;
        playerController.OnCoinCollected += OnCoinCollected;
        playerController.OnSuperSpeedStart += OnSuperSpeedStart;
        playerController.OnSuperSpeedEnd += OnSuperSpeedEnd;

        highScore = PlayerPrefs.GetInt(Constants.HIGH_SCORE_KEY, 0);
    }

    private void OnGameOver() {
        if (currentScore > highScore) {
            highScore = currentScore;
            PlayerPrefs.SetInt(Constants.HIGH_SCORE_KEY, highScore);
        }
        
        gameScore.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        currentScoreValueText.text = currentScore.ToString();
        highScoreValueText.text = highScore.ToString();

        musicAudio.Stop();
        gameOverAudio.Play();
    }

    private void OnCoinCollected() {
        currentScore++;
        gameScore.text = currentScore.ToString();

        coinAudio.Play();
    }

    private void OnSuperSpeedStart() {
        speedAudio.Play();
        musicAudio.pitch = 1.1f;
    }

    private void OnSuperSpeedEnd() {
        musicAudio.pitch = 1;
    }
}
