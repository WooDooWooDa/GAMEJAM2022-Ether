using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private AudioClip pickupClip;
    public abstract void Interact(GameObject player);

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.tag != "npc") {
            collision.GetComponent<Interact>().InteractBubble(true);
        } else if (collision.CompareTag("Player")) {
            collision.GetComponent<Interact>().ChatBubble(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.tag != "npc") {
            collision.GetComponent<Interact>().InteractBubble(false);
        } else if (collision.CompareTag("Player")) {
            collision.GetComponent<Interact>().ChatBubble(false);
        }
    }
}
