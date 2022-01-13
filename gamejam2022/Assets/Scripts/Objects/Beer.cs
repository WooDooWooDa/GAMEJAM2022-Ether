using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : Interactable
{
    [SerializeField] private GameObject thinkingBubble;
    [SerializeField] private GameObject dizzyBubble;

    public override void Interact(GameObject player)
    {
        GetComponent<AudioSource>().Play();
        player.GetComponent<PlayerController>().InvertControl();
        Instantiate(dizzyBubble, player.transform);
        gameObject.SetActive(false);
    }

}
