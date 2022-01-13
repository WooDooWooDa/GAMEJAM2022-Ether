using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _controlsCanvas;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _controlsCanvas.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _controlsCanvas.SetActive(false);
        }
    }
}
