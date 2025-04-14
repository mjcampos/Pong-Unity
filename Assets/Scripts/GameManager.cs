using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] Ball ball;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    
    int countdownTime = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while (countdownTime > 0)
        {
            print(countdownTime);
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        
        StartGame();
    }

    void StartGame()
    {
        // Get ball moving
        ball.StartGame();
        
        // Allow player and enemy to move their paddles
        player.StartGame();
        enemy.StartGame();
    }
}
