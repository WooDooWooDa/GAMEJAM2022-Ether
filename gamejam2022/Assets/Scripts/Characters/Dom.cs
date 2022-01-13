using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dom : npc
{
    [SerializeField] private GameObject tourniquets;

    protected override void DoChoice(DialogueBox box, GameObject player)
    {
        var methodObj = this.GetType().GetMethod(box.GetDialogue().method, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        methodObj.Invoke(this, new object[] { player, box.selectedChoice });
    }

    private void StealTicket(GameObject player, int choice)
    {
        Debug.LogWarning("Steal");
        Debug.Log(choice);
        if (choice == 0)
            tourniquets.SetActive(false);
    }

}
