using UnityEngine;
using UnityEngine.UI;

/**
 * I learned from here: https://www.youtube.com/watch?v=YUcvy9PHeXs&t=210s&ab_channel=CocoCode
 */
/// Manages the game's scoring system, including the display of scores and player health.
public class ScoreManager : MonoBehaviour
{
    /// Singleton instance of the ScoreManager.
    public static ScoreManager instance;

    /// Text UI element for displaying the player's current score.
    public Text scoreText;

    /// Text UI element for displaying the player's high score.
    public Text highscoreText;

    /// Images representing player health/lives.
    public RawImage heart1, heart2, heart3;

    /// Current score of the player.
    public int score = 0;

    /// Player's highest recorded score.
    public int highscore = 0;

    /// Ensures that only one instance of ScoreManager exists.
    private void Awake()
    {
        instance = this;
    }

    /// Initializes the score and high score on game start.
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        UpdateScoreText();
        UpdateHighscoreText();
    }

    /// Adds a point to the player's score and updates the display.
    public void AddPoint()
    {
        score++;
        UpdateScoreText();

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
            UpdateHighscoreText();
        }
    }

    /// Updates the score text UI element.
    private void UpdateScoreText()
    {
        scoreText.text = $"{score} POINTS";
    }

    /// Updates the highscore text UI element.
    private void UpdateHighscoreText()
    {
        highscoreText.text = $"High Score: {highscore}";
    }

    /// Decreases the player's health display by disabling heart images.
    public void RemoveHeart()
    {
        if (Player.currentHealth == 2)
        {
            heart1.enabled = false;
        }
        else if (Player.currentHealth == 1)
        {
            heart2.enabled = false;
        }
        else if (Player.currentHealth == 0)
        {
            heart3.enabled = false;
        }
    }

    /// Increases the player's health display by enabling heart images.
    public void AddHeart()
    {
        if (Player.currentHealth == 2)
        {
            heart1.enabled = true;
            Player.currentHealth++;
        }
        else if (Player.currentHealth == 1)
        {
            heart2.enabled = true;
            Player.currentHealth++;
        }
    }
}