using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    private Vector3 _startPosition;

    void Start() {
        ResetPosition();
    }
    
    void FixedUpdate() {
        float move = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.up * move * speed * Time.deltaTime);
    }

    void ResetPosition() {
        transform.position = new Vector3(-13, 0, 0);
    }
}
