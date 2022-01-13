using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float maxLevelTime;

    private CameraUI cameraUI;
    private float currentTime;
    private bool isPause;

    void Start()
    {
        GetCamera();

        currentTime = maxLevelTime;
    }

    void Update()
    {
        if (isPause)
            return;

        if (cameraUI == null)
            GetCamera();
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            currentTime = 0;
            Lose();
        }

        cameraUI.ShowTime(currentTime);
    }

    private void Lose()
    {
        player.GetComponent<PlayerController>().TogglePlayerMovement();
        player.GetComponent<Interact>().ToggleInteract();
        player.GetComponent<PlayerCamera>().Lose();
    }

    public void TogglePause()
    {
        isPause = !isPause;
    }

    private void GetCamera()
    {
        cameraUI = player.GetComponentInChildren<CameraUI>();
        Debug.Log(cameraUI);
    }

}
