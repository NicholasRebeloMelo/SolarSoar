using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText; // Reference to the UI Text object displaying the high score

    private float currentScore;
    private int highScore;
    public float scoreIncreaseRate; // How much the score increases per second

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0f;  // Initialize score to 0
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        currentScore += scoreIncreaseRate * Time.deltaTime; // Increase score every frame

        // Update the displayed score 
        scoreText.text = Mathf.FloorToInt(currentScore).ToString();
        highScoreText.text = "Hi: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    void OnDestroy() // Called when the GameObject is destroyed 
    {
        // Save the current score as the new high score if it's higher
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", Mathf.FloorToInt(currentScore));
        }
    }
}
