using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager Instance;

    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI enemyScoreText;
    
    int _playerScore = 0;
    int _enemyScore = 0;
    string _gameSceneName = "Game";
    int round = 1;
    int max_rounds = 3;
    bool isGameStillActive = true;
    string playerWins = "You win!";
    string enemyWins = "You lose!";
    string finalMessage;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            // Listen for scene changes
            SceneManager.sceneLoaded += OnSceneLoaded;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        UpdateScoreBoard();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        // If we left the Game scene, destroy this ScoreManager
        if (scene.name != _gameSceneName) {
            Destroy(gameObject);
            return;
        }
        
        // Re-fetch score text UI
        playerScoreText = GameObject.Find("PlayerScoreText").GetComponent<TextMeshProUGUI>();
        enemyScoreText = GameObject.Find("EnemyScoreText").GetComponent<TextMeshProUGUI>();
        
        // Immediately update the score display
        UpdateScoreBoard();
    }

    void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SetEnemyScore() {
        _enemyScore++;
        UpdateScoreBoard();
        UpdateRound();
    }

    public void SetPlayerScore() {
        _playerScore++;
        UpdateScoreBoard();
        UpdateRound();
    }

    public bool GetIsGameStillActive()
    {
        return isGameStillActive;
    }

    public void SetFinalMessage(string message)
    {
        finalMessage = message;
    }

    public string GetFinalMessage()
    {
        return finalMessage;
    }

    void UpdateScoreBoard() {
        playerScoreText.text = _playerScore.ToString();
        enemyScoreText.text = _enemyScore.ToString();
    }

    void UpdateRound() {
        round++;
        
        if (round >= max_rounds) {
            if (_playerScore > _enemyScore) {
                SetFinalMessage(playerWins);
            } else {
                SetFinalMessage(enemyWins);
            }
            
            isGameStillActive = false;
        }
    }
}
