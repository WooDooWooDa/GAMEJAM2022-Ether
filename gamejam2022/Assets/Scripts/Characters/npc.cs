using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class npc : Interactable
{
    [SerializeField] private ReadScript jsonReader;
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private string npcName;

    private GameObject player;
    private List<AllDialogues> allDialogues;
    private int dialogueAt = 0;
    protected int timeVisited = 0;
    private bool isSpeaking = false;
    private bool hasBeenPoked = false;
    private bool dontAutoInteract = false;

    protected abstract void DoChoice(DialogueBox box, GameObject player);

    public override void Interact(GameObject plr)
    {
        if (dontAutoInteract) {
            dontAutoInteract = false;
            return;
        }
        if (timeVisited >= allDialogues.Count) {
            StartCoroutine(dialogueBox.IsAngry());
            return;
        }
        player = plr;

        player.GetComponent<PlayerController>().TogglePlayerMovement();
        player.GetComponent<Interact>().IsSpeaking(true);
        dialogueBox.ToggleBubble();

        isSpeaking = true;
    }

    void Awake()
    {
        NPC npc = jsonReader.GetNpc(npcName);
        if (npc != null) {
            allDialogues = npc.allDialogues;
            dialogueBox.SetName(npcName);
        }
    }

    private void Update()
    {
        if (isSpeaking) {
            dialogueBox.Set(allDialogues[timeVisited].dialogues[dialogueAt]);
            if (Input.GetButtonDown("Interact")) {
                dialogueAt++;
                
                if (dialogueAt >= allDialogues[timeVisited].dialogues.Count) {
                    isSpeaking = false;
                    dialogueAt = 0;
                    Debug.Log("END? : " + allDialogues[timeVisited].chanceOnEndOrChoice);
                    if (allDialogues[timeVisited].chanceOnEndOrChoice == 0)
                        timeVisited++;
                    dontAutoInteract = true;

                    dialogueBox.ToggleBubble();
                    player.GetComponent<PlayerController>().TogglePlayerMovement();
                    player.GetComponent<Interact>().IsSpeaking(false);
                }
                if (dialogueBox.GetDialogue().type == "choice") {
                    DoChoice(dialogueBox, player);
                }
            }
        }
    }
}