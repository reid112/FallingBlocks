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
    public AudioSource loseLifeAudio;
    public AudioSource gainLifeAudio;
    public GameObject gameOverScreen;
    public Text currentScoreValueText;
    public Text highScoreValueText;
    public Text gameScore;
    public Text lives;

    int currentScore = 0;
    int highScore = 0;
    int livesRemaining = 1;

    PlayerController playerController;
    
    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
        playerController.OnHitByBlock += OnHitByBlock;
        playerController.OnCoinCollected += OnCoinCollected;
        playerController.OnSuperSpeedStart += OnSuperSpeedStart;
        playerController.OnSuperSpeedEnd += OnSuperSpeedEnd;
        playerController.OnLifeCollected += OnLifeGained;

        highScore = PlayerPrefs.GetInt(Constants.HIGH_SCORE_KEY, 0);
    }

    private void OnGameOver() {
        if (currentScore > highScore) {
            highScore = currentScore;
            PlayerPrefs.SetInt(Constants.HIGH_SCORE_KEY, highScore);
        }

        Destroy(playerController.gameObject);
        
        gameScore.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        currentScoreValueText.text = currentScore.ToString();
        highScoreValueText.text = highScore.ToString();

        musicAudio.Stop();
        gameOverAudio.Play();
    }

    private void OnHitByBlock(GameObject block) {
        OnLifeLost();

        if (livesRemaining <= 0) {
            OnGameOver();
        } else {
            Destroy(block);
        }
    }

    private void OnCoinCollected() {
        currentScore++;
        gameScore.text = "Score: " + currentScore.ToString();

        coinAudio.Play();
    }

    private void OnSuperSpeedStart() {
        speedAudio.Play();
        musicAudio.pitch = 1.1f;
    }

    private void OnSuperSpeedEnd() {
        musicAudio.pitch = 1;
    }

    private void OnLifeGained() {
        livesRemaining++;
        lives.text = "Lives: " + livesRemaining.ToString();
        gainLifeAudio.Play();
    }

    private void OnLifeLost() {
        livesRemaining--;
        lives.text = "Lives: " + livesRemaining.ToString();
        loseLifeAudio.Play();
    }
}
