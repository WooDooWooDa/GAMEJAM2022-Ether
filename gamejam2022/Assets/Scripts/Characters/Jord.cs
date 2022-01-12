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
        Debug.Log("The player is feeling : " + (choice < 0 ? "GOOD": "BAD"));
    }

    private void Peanut(GameObject player, float choice)
    {
        if (player.GetComponent<Inventory>().Contains("peanut"))
            timeVisited++;
        Debug.Log("The player as the peanut answer : " + (choice < 0 ? "YES" : "NO"));
        Debug.Log("Does he? : " + (player.GetComponent<Inventory>().Contains("peanut") ? "YES" : "NO"));
    }
}
