using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jord : npc
{
    protected override void DoChoice(DialogueBox box, GameObject player)
    {
        var methodObj = this.GetType().GetMethod(box.GetDialogue().method, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        methodObj.Invoke(this, new object[] { player, box.selectedChoice });
    }

    private void Feeling(GameObject player, float choice)
    {
        
    }

    private void Peanut(GameObject player, float choice)
    {
        if (player.GetComponent<Inventory>().Contains("peanut") && choice == 0) {
            Debug.Log("Gat ya peanut !");
            readyToChange = true;
        } else if (choice == 1) {
            dialogueBox.selectedChoice = 1;
        } else if (choice == 0 && !player.GetComponent<Inventory>().Contains("peanut")) {
            dialogueBox.selectedChoice = 2;
        }
            
    }
}
