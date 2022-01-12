using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    public override void Interact(GameObject player)
    {
        LevelLetter letter = player.GetComponent<Inventory>().Contains("letter").GetComponent<LevelLetter>();
        Debug.LogWarning(letter);
        if (letter) {
            SceneManager.LoadScene("level" + letter.GetLevel());
        }
    }

}
