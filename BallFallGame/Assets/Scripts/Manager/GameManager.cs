using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public Text scoreText;

    public int score;
    public Text lastScoreText;
    public Text highScoreText;

    public GameObject restartPanel;

    private float fallTime;
    private int point=1;
    private int highScore;


    private void Start()
    {
        Instance = this;
        score = 0;
        Time.timeScale = 1;
        scoreText.text = score.ToString();
        
        if (PlayerPrefs.HasKey("Score"))
        {
            highScore = PlayerPrefs.GetInt("Score");
            highScoreText.text = highScore.ToString();
        }
        restartPanel.SetActive(false);
    }
    private void Update()
    {
        if (Time.time- fallTime>0.5f)
        {
            fallTime = 0;
            point = 1;
        }
    }

    //隨著時間
    public void AddScore()
    {
        if (fallTime == 0)
        {
            score++;
            fallTime = Time.time;
        }
        else if (fallTime!=0&& Time.time - fallTime < 0.5f)
        {
            point = point +1;
            score += point;
            fallTime = Time.time;
        }
        
        scoreText.text = score.ToString();
        FloatingTextController.Instance.CreateFloatingText("+"+point);


    }

    public void Save()
    {
        if (score>highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Score", score);
        }
        
    }

    public void GameOver()
    {
        Save();
        restartPanel.SetActive(true);
        lastScoreText.text = score.ToString();
        if (highScore == 0)
        {
            highScoreText.text = "無紀錄";
        }
        else
        {
            highScoreText.text ="High Score is "+ highScore.ToString();

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
