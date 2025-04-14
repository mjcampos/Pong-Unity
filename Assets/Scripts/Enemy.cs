using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private Transform ball;
    [SerializeField] private float speed = 5f;
    
    private bool gameStarted = false;

    // Update is called once per frame
    void FixedUpdate() {
        if (ball == null) {
            return;
        }

        if (gameStarted) {
            float ballY = ball.position.y;
            float paddleY = transform.position.y;
        
            // Move toward the ball's Y position
            Vector3 newPosition = transform.position;
        
            newPosition.y = Mathf.MoveTowards(paddleY, ballY, speed * Time.deltaTime);
            transform.position = newPosition;
        }
    }

    public void StartGame() {
        gameStarted = true;
    }
}
