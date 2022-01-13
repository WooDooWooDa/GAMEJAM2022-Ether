using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraUI : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject timeScreen;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private TextMeshProUGUI returnIn;

    [SerializeField] private TextMeshProUGUI currentTime;

    private bool isStarted = false;

    private void Awake()
    {
        timeScreen.SetActive(SceneManager.GetActiveScene().name != "QG");
    }

    public void ShowWinner()
    {
        endText.text = "Vous avez bien livrer la lettre d'amour � la bonne personne! <3";
        endScreen.SetActive(true);
        if (!isStarted) {
            isStarted = true;
            StartCoroutine(ToQG());
        }
    }

    public void ShowLoser()
    {
        endText.text = "Vous n'avez pas trouver le bon destinataire...";
        endScreen.SetActive(true);
        if (!isStarted) {
            isStarted = true;
            StartCoroutine(ToQG());
        }
        
    }

    public void ShowTime(float time)
    {
        var timeSpan = TimeSpan.FromSeconds(time);
        currentTime.text = $"{timeSpan.Minutes.ToString("00")}:{timeSpan.Seconds.ToString("00")}";
    }

    private IEnumerator ToQG()
    {
        Debug.LogWarning("Start");
        int counter = 5;
        while (counter > 0) {
            returnIn.text = counter.ToString();
            yield return new WaitForSeconds(1);
            counter--;
        }
        SceneManager.LoadScene("QG");
    }
}
