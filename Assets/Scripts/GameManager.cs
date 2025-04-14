using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    void Awake() {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
