using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PQ : Interactable
{
    public override void Interact(GameObject player)
    {
        GetComponent<AudioSource>().Play();
        var inventory = player.GetComponent<Inventory>();
        if (!inventory.Contains("pq"))
            inventory.Add("pq", gameObject);
        gameObject.SetActive(false);
    }
}
