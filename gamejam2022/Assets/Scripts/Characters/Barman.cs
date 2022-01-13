using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barman : npc
{
    [SerializeField] private Pooler pooler;
    
    protected override void DoChoice(DialogueBox box, GameObject player)
    {
        var methodObj = this.GetType().GetMethod(box.GetDialogue().method, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        methodObj.Invoke(this, new object[] { player, box.selectedChoice });
    }
    
    private void TalkedToBarman(GameObject player, int choice)
    {
        pooler.GetComponent<npc>().timeVisited = 1;
    }
}
