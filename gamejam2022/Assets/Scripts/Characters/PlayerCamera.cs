using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject _cameraPrefab;

    private GameObject cameraObj;

    void Start()
    {
        var cameraInstance = Instantiate(_cameraPrefab, new Vector3(0, 0, -10f), Quaternion.identity, gameObject.transform);
        cameraObj = cameraInstance;
        cameraInstance.GetComponent<CameraControl>().target = gameObject;
    }

    public void Win()
    {
        GameObject.FindObjectOfType<GameTime>().TogglePause();
        cameraObj.GetComponentInChildren<CameraUI>().ShowWinner();
    }

    public void Lose() {
        GameObject.FindObjectOfType<GameTime>().TogglePause();
        cameraObj.GetComponentInChildren<CameraUI>().ShowLoser();
    }
    
}
