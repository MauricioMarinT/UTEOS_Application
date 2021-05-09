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


        // StartGame metodo que inicia la partida
        //Param difficulty indica el gradod e dificultad

    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);
        panelScore.gameObject.SetActive(true);
        spawnRate /= difficulty;
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

    public void GameOver()
    {
        panelGameOver.gameObject.SetActive(true);
        gameState = GameState.gameOver;
        titleEnd.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
