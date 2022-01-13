using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : InteractableObject
{
    [SerializeField] private GameObject thinkingBubble;
    [SerializeField] private GameObject dizzyBubble;

    public override void Interact(GameObject player)
    {
        PlayInteractSound();
        player.GetComponent<PlayerController>().InvertControl();
        Instantiate(dizzyBubble, player.transform);
        gameObject.SetActive(false);
    }

}
