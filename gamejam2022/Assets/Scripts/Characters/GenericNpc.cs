using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNpc : npc
{

    protected override void DoChoice(DialogueBox box, GameObject player)
    {
        if (box.selectedChoice == 0) {
            Lose(player);
        }
    }

    private void Lose(GameObject player)
    {
        player.GetComponent<PlayerController>().TogglePlayerMovement();
        player.GetComponent<Interact>().ToggleInteract();
        player.GetComponent<PlayerCamera>().Lose();
    }
}
