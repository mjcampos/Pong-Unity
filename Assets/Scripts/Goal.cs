using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    int countdownTime = 1;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (gameObject.CompareTag("Player Goal")) {
            ScoreManager.Instance.SetEnemyScore();
        } 
        
        if (gameObject.CompareTag("Enemy Goal")) {
            ScoreManager.Instance.SetPlayerScore();
        }
        
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine() {
        yield return new WaitForSeconds(countdownTime);
        SceneManager.LoadScene("Game");
    }
}
