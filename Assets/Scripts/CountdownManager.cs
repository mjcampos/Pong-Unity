using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownManager : MonoBehaviour {
    public static CountdownManager Instance;
    
    [SerializeField] Ball ball;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    
    [SerializeField] TextMeshProUGUI countdownText;
    
    int countdownTime = 3;

    void Awake() {
        // Singleton pattern
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    void Start() {
        countdownText.text = "";
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine() {
        while (countdownTime > 0) {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        
        countdownText.text = "";
        
        StartGame();
    }
    
    void StartGame() {
        // Get ball moving
        ball.StartGame();
        
        // Allow player and enemy to move their paddles
        player.StartGame();
        enemy.StartGame();
    }
}
