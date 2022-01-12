using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNpc : npc
{

    protected override void DoChoice(DialogueBox box, GameObject player)
    {
        if (box.selectedChoice == 0) {
            //perd!
            readyToChange = true;
        }
    }
}
