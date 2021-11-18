using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Text pointText;
    private int points = 0;
    private float restartSceneCounter = 0;
    private bool restartSceneFlag = false;
    public float restartSceneCD;
    public AdManager adManager;

    private void Start()
    {
        if (PlayerPrefs.HasKey("points"))
        {
            points = PlayerPrefs.GetInt("points");
            pointText.text = points.ToString();
        }
    }

    public void onPlayerDeath()
    {
        // Store points to spend
        if (PlayerPrefs.HasKey("points"))
        { 
            int currentStorePoints = PlayerPrefs.GetInt("points");
            currentStorePoints += points;
            PlayerPrefs.SetInt("points", points);
        }
        else
        {
            PlayerPrefs.SetInt("points", points);
        }

        if (PlayerPrefs.HasKey("HighScore"))
        {
            int highScore = PlayerPrefs.GetInt("HighScore");
            if (points > highScore)
            {
                PlayerPrefs.SetInt("HighScore", points);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", points);
        }

        // Wait for death particle to happen
        restartSceneFlag = true;

        // Change scene to menu, or something
    }

    private void Update()
    {
        if (restartSceneFlag)
        {
            restartSceneCounter += Time.deltaTime;
            if (restartSceneCD < restartSceneCounter)
            {
                adManager.DisplayAd();
                SceneManager.LoadScene(0);
            }
        }
    }

    public void incrementPlayerKill()
    {
        points++;
        pointText.text = points.ToString();
    }
}
