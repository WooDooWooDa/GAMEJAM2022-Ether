using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : npc
{
    private int levelBit = 4;

    protected override void DoChoice(DialogueBox box, GameObject player)
    {
        var methodObj = this.GetType().GetMethod(box.GetDialogue().method, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        methodObj.Invoke(this, new object[] { player, box.selectedChoice });
    }

    //private void 

    private void Letter(GameObject player, int choice)
    {
        if (choice == 0) {
            Win(player);
        } else {
            dialogueBox.selectedChoice = 1;
        }
    }

    private void Lose(GameObject player)
    {
        StopPlayer(player);
        player.GetComponent<PlayerCamera>().Lose();
    }

    private void Win(GameObject player)
    {
        StopPlayer(player);
        player.GetComponent<PlayerCamera>().Win();

        int playerLevel = PlayerPrefs.GetInt("levels");
        playerLevel += levelBit;
        PlayerPrefs.SetInt("levels", playerLevel);
    }

    private void StopPlayer(GameObject player)
    {
        player.GetComponent<PlayerController>().TogglePlayerMovement();
        player.GetComponent<Interact>().ToggleInteract();
    }
}
