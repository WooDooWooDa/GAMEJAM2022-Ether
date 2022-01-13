using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraUI : MonoBehaviour
{
    [SerializeField] private GameObject winnerScreen;
    [SerializeField] private TextMeshProUGUI returnIn;
    [SerializeField] private GameObject loserScreen;

    public void ShowWinner()
    {
        winnerScreen.SetActive(true);
        StartCoroutine(ToQG());
    }

    public void ShowLoser()
    {
        loserScreen.SetActive(true);
        StartCoroutine(ToQG());
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
