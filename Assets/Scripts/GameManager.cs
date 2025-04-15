using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
