using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour {
    [SerializeField] float speed = 10f;
    
    Rigidbody2D _rigidbody2D;
    AudioSource _audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        
        ResetBall();
    }

    void LaunchBall() {
        // Launch in a random direction
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        
        Vector2 direction = new Vector2(x, y).normalized;
        
        _rigidbody2D.linearVelocity = direction * speed;
    }

    void ResetBall() {
        transform.position = Vector2.zero;
        _rigidbody2D.linearVelocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Paddle")) {
            float paddleY = other.collider.transform.position.y;
            float contactY = transform.position.y;
            float paddleHeight = other.collider.bounds.size.y;
            
            float offset = contactY - paddleY;
            float normalizedOffset = offset / (paddleHeight / 2);
            
            // Create a new direction with the same horizontal direction but new vertical angle
            Vector2 direction = new Vector2(_rigidbody2D.linearVelocity.x > 0 ? -1 : 1, normalizedOffset).normalized;
            _rigidbody2D.linearVelocity = direction * speed;
        }
        
        // No matter what it hits, play collision sound
        _audioSource.Play();
    }

    public void StartGame() {
        // Get ball moving
        LaunchBall();
    }
}
