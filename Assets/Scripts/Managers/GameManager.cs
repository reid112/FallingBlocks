using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource musicAudio;
    public AudioSource gameOverAudio;
    public AudioSource coinAudio;
    public AudioSource rareCoinAudio;
    public AudioSource speedAudio;
    public AudioSource loseLifeAudio;
    public AudioSource gainLifeAudio;
    public GameObject gameOverScreen;
    public Text currentScoreValueText;
    public Text highScoreValueText;
    public Text gameScore;
    public Text lives;

    private int currentScore = 0;
    private int highScore = 0;
    private int livesRemaining = 1;

    private PlayerController playerController;
    
    private void Start() {
        playerController = FindObjectOfType<PlayerController>();

        playerController.OnHitByBlock += OnHitByBlock;
        playerController.OnCoinCollected += OnCoinCollected;
        playerController.OnRareCoinCollected += OnRareCoinCollected;
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
        currentScore += Constants.COIN_VALUE;
        gameScore.text = Constants.SCORE_LABEL + currentScore.ToString();

        coinAudio.Play();
    }

    private void OnRareCoinCollected() {
        currentScore += Constants.RARE_COIN_VALUE;
        gameScore.text = Constants.SCORE_LABEL + currentScore.ToString();

        rareCoinAudio.Play();
    }

    private void OnSuperSpeedStart() {
        speedAudio.Play();
        musicAudio.pitch = Constants.SPEED_POWER_UP_MULTIPLIER;
    }

    private void OnSuperSpeedEnd() {
        musicAudio.pitch = 1;
    }

    private void OnLifeGained() {
        livesRemaining++;
        lives.text = Constants.LIVES_LABEL + livesRemaining.ToString();
        gainLifeAudio.Play();
    }

    private void OnLifeLost() {
        livesRemaining--;
        lives.text = Constants.LIVES_LABEL + livesRemaining.ToString();
        loseLifeAudio.Play();
    }
}
