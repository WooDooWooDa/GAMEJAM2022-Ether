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

    private void Awake()
    {
        timeScreen.SetActive(SceneManager.GetActiveScene().name != "QG");
    }

    public void ShowWinner()
    {
        endText.text = "Vous avez bien livrer la lettre d'amour à la bonne personne! <3";
        endScreen.SetActive(true);
        StartCoroutine(ToQG());
    }

    public void ShowLoser()
    {
        endText.text = "Vous n'avez pas trouver le bon destinataire...";
        endScreen.SetActive(true);
        StartCoroutine(ToQG());
    }

    public void ShowTime(float time)
    {
        var timeSpan = TimeSpan.FromSeconds(time);
        currentTime.text = $"{timeSpan.Minutes.ToString("00")}:{timeSpan.Seconds.ToString("00")}";
    }

    private IEnumerator ToQG()
    {
        for (int i = 5; i > 0; i--) {
            returnIn.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("QG");
    }
}
