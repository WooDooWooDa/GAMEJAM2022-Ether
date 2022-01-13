using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
   
    private PlayerController _player;
    private bool isPaused = false;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
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
    }

    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        _player.enabled = true;
        isPaused = false;
    }

    public void Quit()
    {
        print("Tried to quit"); 
        
        SceneManager.LoadScene(0);
    }
}
