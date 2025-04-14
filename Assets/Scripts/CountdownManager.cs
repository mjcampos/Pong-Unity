using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownManager : MonoBehaviour {
    public static CountdownManager Instance;
    
    [SerializeField] Ball ball;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    
    int countdownTime = 1;

    void Awake() {
        // Singleton pattern
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;

        StartCoroutine(CountdownRoutine());
    }
    
    IEnumerator CountdownRoutine() {
        while (countdownTime > 0) {
            print(countdownTime);
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        
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
