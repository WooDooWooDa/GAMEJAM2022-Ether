using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Interactable
{
    [SerializeField] private string foodType;

    public override void Interact(GameObject player)
    {
        var inventory = player.GetComponent<Inventory>();
        if (!inventory.Contains(foodType))
            inventory.Add(foodType, gameObject);
        gameObject.SetActive(false);
    }
}
