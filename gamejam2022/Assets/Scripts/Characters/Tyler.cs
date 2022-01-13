using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tyler : npc
{
    private int levelBit = 1;

    protected override void DoChoice(DialogueBox box, GameObject player)
    {
        var methodObj = this.GetType().GetMethod(box.GetDialogue().method, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        methodObj.Invoke(this, new object[] { player, box.selectedChoice });
    }

    private void PQ(GameObject player, int choice)
    {
        if(player.GetComponent<Inventory>().Contains("pq") && choice == 1) {
            readyToChange = true;
        } else if (choice == 1 && !player.GetComponent<Inventory>().Contains("pq")) {
            dialogueBox.selectedChoice = 2;
        } else {
            Lose(player);
            dialogueBox.selectedChoice = 0;
        }
    }

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
