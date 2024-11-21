
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=YUcvy9PHeXs&t=210s&ab_channel=CocoCode
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    public RawImage heart1;
    public RawImage heart2;
    public RawImage heart3;

    public int score = 0;
    public int highscore = 0;

    private void Awake( ) { instance = this; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "High Score: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
       }


        public void RemoveHeart()
    {
        // Assuming you have a reference to a Player object with a health property
        if (Player.currentHealth == 2)
        {
            heart1.enabled = false; // Hide the third heart
        }

        if (Player.currentHealth == 1)
        {
            heart2.enabled = false; // Hide the second heart
        }

        if (Player.currentHealth == 0)
        {
            heart3.enabled = false; // Hide the first heart
        }
    }

    public void AddHeart()
    {
        // Assuming you have a reference to a Player object with a health property
        if (Player.currentHealth == 2)
        {
            heart1.enabled = true; 
            Player.currentHealth++;
        }

        if (Player.currentHealth == 1)
        {
            heart2.enabled = true; 
            Player.currentHealth++;
        }
    }
}
