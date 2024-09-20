using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI ScoreText;
    private int highScore;
    private int score;
    private int previousScore = 0;
    private float timer = 0f;
    private GameManagement gameManagement;

    void Start()
    {
        LoadHighScore();
        gameManagement = GetComponent<GameManagement>();
    }

    void Update()
    {
        if(!GameManagement.IsGameOver)
        {
            timer += Time.deltaTime;
            score = Mathf.RoundToInt(timer);
            ScoreText.text = "Score: " + score.ToString();
            if(score != previousScore && score % 10 == 0)
            {
                GameManagement.GameSpeed += 0.5f;
                Debug.Log("Game speed:" + GameManagement.GameSpeed.ToString());
            }
            previousScore = score;
        }

    }

    public void SetHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }

    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("PlayerScore", highScore);
        PlayerPrefs.Save();
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("PlayerScore", 0);
        HighScoreText.text = "High Score: " + highScore.ToString();
    }

    public void ResetScore()
    {
        timer = 0;
        LoadHighScore();
    }

    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("PlayerScore", highScore);
        PlayerPrefs.Save();
    }
}
