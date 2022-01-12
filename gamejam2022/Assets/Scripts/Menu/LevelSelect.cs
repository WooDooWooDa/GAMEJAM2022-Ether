using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private List<LevelLetter> letters;

    private void Start()
    {
        int playerLevel = PlayerPrefs.GetInt("levels");
        if (playerLevel == 0) {
            for (int i = 1; i < letters.Count; i++) {
                letters[i].gameObject.SetActive(false);
            }
            return;
        }
        int bit = 1;
        for (int i = 0; i < letters.Count; i++) {
            letters[i].gameObject.SetActive((playerLevel & bit) == 0);
            bit <<= 1;
        }
    }
}
