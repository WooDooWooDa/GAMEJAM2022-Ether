using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PQ : InteractableObject
{
    public override void Interact(GameObject player)
    {
        PlayInteractSound();
        var inventory = player.GetComponent<Inventory>();
        if (!inventory.GetInventoryItem("pq"))
            inventory.Add("pq", gameObject);
        gameObject.SetActive(false);
    }
}
