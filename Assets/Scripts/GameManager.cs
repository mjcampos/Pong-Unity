using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    
    bool _restartOptionActive = false;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Main Menu");
        }

        if (_restartOptionActive) {
            if (Input.GetKeyDown(KeyCode.R)) {
                ScoreManager.Instance.RestartScore();
            }
        }
    }

    public void SetRestartOption(bool restart) {
        _restartOptionActive = restart;
    }
}
