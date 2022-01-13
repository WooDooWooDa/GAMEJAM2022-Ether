using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dracula : npc
{
    private int levelBit = 2;

    protected override void DoChoice(DialogueBox box, GameObject player)
    {
        var methodObj = this.GetType().GetMethod(box.GetDialogue().method, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        methodObj.Invoke(this, new object[] { player, box.selectedChoice });
    }

    private void Food(GameObject player, int choice)
    {
        if (choice == 1) {
            dialogueBox.selectedChoice = 1;
        } else if (player.GetComponent<Inventory>().GetInventoryItem("food") == null && choice == 0) {
            dialogueBox.selectedChoice = 2;
        } else if (player.GetComponent<Inventory>().GetInventoryItem("food").GetComponent<Food>().foodType == "garlic") {
            dialogueBox.selectedChoice = 3;
            Lose(player);
        } else if (player.GetComponent<Inventory>().GetInventoryItem("food").GetComponent<Food>().foodType == "spicy") {
            dialogueBox.selectedChoice = 0;
            readyToChange = true;
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
