using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tyler : npc
{
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
            dialogueBox.selectedChoice = 0;
        }
    }

}
