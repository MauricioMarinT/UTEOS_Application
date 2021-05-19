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
    public float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    private QuizManager quizManager;
   
    
    private int _score;

    public int score
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
    public GameObject panelLife;
    public GameObject panelGameOver;
    public GameObject titleEnd;
    public GameObject panelQ;
    
    private int numberOfLives = 4;

    public List<GameObject> lives;
        // StartGame metodo que inicia la partida
        //Param difficulty indica el grado de dificultad
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);
        panelScore.gameObject.SetActive(true);
        panelLife.gameObject.SetActive(true);
        panelQ.gameObject.SetActive(false);
        spawnRate /= difficulty;
        numberOfLives -= difficulty;
        for (int i = 0; i<numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }
        StartCoroutine(routine: SpawnTarget());
        score = 0;
        UpdateScore(0,3);
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
    public void PanelHide(int gato)
    {
        if (gato==1)
        {
            panelQ.gameObject.SetActive(false);
        }
    }
    
    public void UpdateScore(int scoreToAdd,int cerdo)
    {
        score += scoreToAdd;
        scoreText.text= "Score; " + score;
       switch (score)
        {
            case 10:
                if (cerdo==1)
                {
                    score += 5;
                    scoreText.text= "Score; " + score;
                }else if (cerdo==0)
                {
                    score -= 4;
                    scoreText.text= "Score; " + score;
                }
                else
                {
                    panelQ.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    score += 0;
                }
                break;
            case 20:
                if (cerdo==1)
                {
                    score += 7;
                    scoreText.text= "Score; " + score;
                }else if (cerdo==0)
                {
                    score -= 5;
                    scoreText.text= "Score; " + score;
                }
                else
                {
                    panelQ.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    score += 0;
                }
                break;
            case 30:
                if (cerdo==1)
                {
                    score += 9;
                    scoreText.text= "Score; " + score;
                }else if (cerdo==0)
                {
                    score -= 7;
                    scoreText.text= "Score; " + score;
                }
                else
                {
                    panelQ.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    score += 0;
                }
                break;
            case 40:
                if (cerdo==1)
                {
                    score += 11;
                    scoreText.text= "Score; " + score;
                }else if (cerdo==0)
                {
                    score -= 9;
                    scoreText.text= "Score; " + score;
                }
                else
                {
                    panelQ.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    score += 0;
                }
                break;
            case 50:
                if (cerdo==1)
                {
                    score += 13;
                    scoreText.text= "Score; " + score;
                }else if (cerdo==0)
                {
                    score -= 11;
                    scoreText.text= "Score; " + score;
                }
                else
                {
                    panelQ.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    score += 0;
                }
                break;
            case 60:
                if (cerdo==1)
                {
                    score += 15;
                    scoreText.text= "Score; " + score;
                }else if (cerdo==0)
                {
                    score -= 13;
                    scoreText.text= "Score; " + score;
                }
                else
                {
                    panelQ.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    score += 0;
                }
                break;
            case 70:
                if (cerdo==1)
                {
                    score += 17;
                    scoreText.text= "Score; " + score;
                }else if (cerdo==0)
                {
                    score -= 13;
                    scoreText.text= "Score; " + score;
                }
                else
                {
                    panelQ.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    score += 0;
                }
                break;
            case 80:
                if (cerdo==1)
                {
                    score += 21;
                    scoreText.text= "Score; " + score;
                }else if (cerdo==0)
                {
                    score -= 15;
                    scoreText.text= "Score; " + score;
                }
                else
                {
                    panelQ.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    score += 0;
                }
                break;
            case 90:
                if (cerdo==1)
                {
                    score += 13;
                    scoreText.text= "Score; " + score;
                }else if (cerdo==0)
                {
                    score -= 11;
                    scoreText.text= "Score; " + score;
                }
                else
                {
                    panelQ.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    score += 0;
                }
                break;
            case 100:
                if (cerdo==1)
                {
                    score += 27;
                    scoreText.text= "Score; " + score;
                }else if (cerdo==0)
                {
                    score -= 19;
                    scoreText.text= "Score; " + score;
                }
                else
                {
                    panelQ.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    score += 0;
                }
                break;
        }
       
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
