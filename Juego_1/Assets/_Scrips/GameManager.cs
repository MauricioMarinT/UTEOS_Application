using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{



    private void Start()
    {
        ShowMaxScore();
    }

    public enum GameState
    {
        inGame,
        paused,
        gameOver
    }

    public GameState gameState;

    public List<GameObject> targetPrefabs;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    
    private int _score;

    private int score
    {
        set
        {
            _score = Mathf.Max(value, 0);
        }
        get
        {
            return _score;
        }
    }

    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen ;
    public GameObject panelScore;
    public GameObject panelGameOver;
    public GameObject titleEnd;

    private int numberOfLives = 4;

    public List<GameObject> lives;
        // StartGame metodo que inicia la partida
        //Param difficulty indica el grado de dificultad
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);
        panelScore.gameObject.SetActive(true);
        spawnRate /= difficulty;
        numberOfLives -= difficulty;
        for (int i = 0; i<numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }
        StartCoroutine(routine: SpawnTarget());
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
    }
   
    
    
    
    IEnumerator SpawnTarget()
    {
        while (gameState==GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text= "Score; " + score;
    }

    private const string MAX_SCORE = "MAX_SCORE";
    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt("MAX_SCORE",0);
        scoreText.text = ("Max Score: \n" + maxScore);
    }

    public void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt("MAX_SCORE",0);
        if (score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE,score);
        }   
    }
    
    public void GameOver()
    {
        numberOfLives--;
        if (numberOfLives >= 0)
        {
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor; 
        }
        if (numberOfLives == 0)
        {
            SetMaxScore();
            panelGameOver.gameObject.SetActive(true);
            gameState = GameState.gameOver;
            titleEnd.gameObject.SetActive(true); 
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
