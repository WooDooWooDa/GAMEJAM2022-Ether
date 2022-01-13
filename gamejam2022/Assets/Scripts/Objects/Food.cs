using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Interactable
{
    [SerializeField] public string foodType;

    public override void Interact(GameObject player)
    {
        var inventory = player.GetComponent<Inventory>();
        if (!inventory.GetInventoryItem("food"))
            inventory.Add("food", gameObject);
        gameObject.SetActive(false);
    }
}
