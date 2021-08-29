using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffilcutyButton : MonoBehaviour
{

    private Button _button;
    private GameManager gameManager; 
    
    [Range(1,3)]
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
