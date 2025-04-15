using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    int countdownTime = 1;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        yield return new WaitForSeconds(countdownTime);
        SceneManager.LoadScene("Game");
    }
}
