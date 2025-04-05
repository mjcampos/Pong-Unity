using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] float _speed = 10f;
    
    private Rigidbody2D _rigidbody2D;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        ResetBall();
        LaunchBall();
    }

    void LaunchBall() {
        // Launch in a random direction
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        
        Vector2 direction = new Vector2(x, y).normalized;
        
        _rigidbody2D.linearVelocity = direction * _speed;
    }

    void ResetBall() {
        transform.position = Vector2.zero;
        _rigidbody2D.linearVelocity = Vector2.zero;
    }
}
