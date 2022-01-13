using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peanuts : Interactable
{
    public override void Interact(GameObject player)
    {
        var inventory = player.GetComponent<Inventory>();
        if (!inventory.GetInventoryItem("peanut"))
            inventory.Add("peanut", gameObject);
        gameObject.SetActive(false);
    }
}
