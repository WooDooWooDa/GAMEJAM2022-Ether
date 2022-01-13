using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject interactionBubble;
    [SerializeField] private GameObject chatBubble;

    private Vector2 boxsize = new Vector2(1.4f, 1.7f);
    private bool isSpeaking = false;
    private bool canInteract = true;

    private void Update()
    {
        if (isSpeaking) {
            InteractBubble(false);
            ChatBubble(false);
            return;
        }

        if (Input.GetButtonDown("Interact") && canInteract) {
            GetComponent<Animator>().SetTrigger("Interact");
            CheckInteractions();
        }
    }

    public void ToggleInteract()
    {
        canInteract = !canInteract;
    }

    public void ChatBubble(bool set)
    {
        chatBubble.SetActive(set);
    }

    public void InteractBubble(bool set)
    {
        interactionBubble.SetActive(set);
    }

    public void IsSpeaking(bool value)
    {
        isSpeaking = value;
    }

    private void CheckInteractions()
    {
        //Debug.Log("CheckInteractions!");
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxsize, 0, Vector2.zero);

        if (hits.Length > 0) {
            foreach (RaycastHit2D ray in hits) {
                if (ray.transform.TryGetComponent<Interactable>(out var interactable)) {
                    interactable.Interact(gameObject);
                    return;
                }
            }
        }
    }
}
