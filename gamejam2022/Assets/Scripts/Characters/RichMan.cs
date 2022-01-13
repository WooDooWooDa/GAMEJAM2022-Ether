using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichMan : npc
{
    protected override void DoChoice(DialogueBox box, GameObject player)
    {
        var methodObj = this.GetType().GetMethod(box.GetDialogue().method, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        methodObj.Invoke(this, new object[] { player, box.selectedChoice });
    }

    private void SeeAgain(GameObject player, int choice)
    {
        timeVisited = 0;
    }
}
