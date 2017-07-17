using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool isRecording = true;
    private bool isPaused = false;
    private float fixedDeltaTime;

    private void Start() {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1")) {
            isRecording = false;
        } else {
            isRecording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused) {
            isPaused = false;
            ResumeGame();
        } else if (Input.GetKeyDown(KeyCode.P) && !isPaused) {
            isPaused = true;
            PauseGame();
        }

    }

    void PauseGame(){
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
    }

    void ResumeGame() {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    private void OnApplicationPause(bool pause) {
        isPaused = pause;
    }
}
