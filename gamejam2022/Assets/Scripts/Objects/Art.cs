using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Art : Interactable
{
    [SerializeField] private GameObject crak;

    public override void Interact(GameObject player)
    {
        Instantiate(crak, transform);
        //Lose(player);
    }

    private void Lose(GameObject player)
    {
        player.GetComponent<PlayerController>().TogglePlayerMovement();
        player.GetComponent<Interact>().ToggleInteract();
        player.GetComponent<PlayerCamera>().Lose();
    }
}
