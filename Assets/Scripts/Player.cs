using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    private Vector3 _startPosition;

    void Start() {
        ResetPosition();
    }

    // Update is called once per frame
    void LateUpdate() {
        float move = Input.GetAxis("Vertical");
        
        transform.Translate(0, move * speed * Time.deltaTime, 0);
    }

    void ResetPosition() {
        transform.position = new Vector3(-13, 0, 0);
    }
}
