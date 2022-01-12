using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject interactionBubble;

    private Vector2 boxsize = new Vector2(0.1f, 1f);
    private bool isSpeaking = false;

    private void Update()
    {
        if (isSpeaking) {
            InteractBubble(false);
            return;
        }

        if (Input.GetButtonDown("Interact")) {
            GetComponent<Animator>().SetTrigger("Interact");
            CheckInteractions();
        }
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
        Debug.Log("CheckInteractions!");
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
