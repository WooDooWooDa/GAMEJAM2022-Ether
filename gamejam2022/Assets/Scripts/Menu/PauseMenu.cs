using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameTime gameTime;
   
    private PlayerController _player;
    private bool isPaused = false;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (gameTime == null)


        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        _player.enabled = false;
        isPaused = true;
        gameTime.TogglePause();
    }

    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        _player.enabled = true;
        isPaused = false;
        gameTime.TogglePause();
    }

    public void Quit()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("QG")) {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(1);
        }
    }
}
