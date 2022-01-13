using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peanuts : InteractableObject
{
    public override void Interact(GameObject player)
    {
        PlayInteractSound();
        var inventory = player.GetComponent<Inventory>();
        if (!inventory.GetInventoryItem("peanut"))
            inventory.Add("peanut", gameObject);
        gameObject.SetActive(false);
    }
}
