using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    public override void Interact(GameObject player)
    {
        var letter = player.GetComponent<Inventory>().GetInventoryItem("letter").GetComponent<LevelLetter>();
        if (letter) {
            SceneManager.LoadScene("level" + letter.GetLevel());
        }
    }

}
