using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class npc : Interactable
{
    [SerializeField] private ReadScript jsonReader;
    [SerializeField] protected DialogueBox dialogueBox;
    [SerializeField] private string npcName;

    private GameObject player;
    private List<AllDialogues> allDialogues;
    private int dialogueAt = 0;
    protected internal int timeVisited = 0;
    private bool isSpeaking = false;
    protected internal bool readyToChange = false;
    private bool preventFirstInteract = false;
    private bool preventInteract = false;
    private bool tryForBetterName = true;

    protected abstract void DoChoice(DialogueBox box, GameObject player);

    public override void Interact(GameObject plr)
    {
        if (preventFirstInteract) {
            preventFirstInteract = false;
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
        preventFirstInteract = true;
    }

    void Awake()
    {
        NPC npc = jsonReader.GetNpc(npcName);
        if (npc != null) {
            allDialogues = npc.allDialogues;
            dialogueBox.SetName(npcName);
        }
    }
    
    private void TrySetBetterName()
    {
        // Try to set a better name on first time only
        if (tryForBetterName)
        {
            tryForBetterName = false;
            try
            {
                if (TryGetComponent<MultiSpriteSwaper>(out var spriteSwapper))
                {
                    var displayName = jsonReader.GetNpcDisplayName(npcName, spriteSwapper.SpriteIndex) ?? npcName;
                    dialogueBox.SetName(displayName);
                }
            }
            catch
            {
                // Just making sure I don't break something
            }
        }
    }

    private void Update()
    {
        TrySetBetterName();
        
        if (isSpeaking) {
            GetComponent<NPCAI>().Immobilize(true);
            dialogueBox.Set(allDialogues[timeVisited].dialogues[dialogueAt]);
            if (Input.GetButtonDown("Interact") && !preventFirstInteract) {
                preventFirstInteract = false;
                dialogueAt++;
                
                if (dialogueAt >= allDialogues[timeVisited].dialogues.Count) {
                    isSpeaking = false;
                    dialogueAt = 0;
                    
                    if (allDialogues[timeVisited].repeat == 0)
                        timeVisited++;
                    else if (readyToChange) {
                        timeVisited++;
                        readyToChange = false;
                    }
                    preventFirstInteract = true;

                    dialogueBox.ToggleBubble();
                    dialogueBox.Reset();
                    player.GetComponent<PlayerController>().TogglePlayerMovement();
                    player.GetComponent<Interact>().IsSpeaking(false);
                    GetComponent<NPCAI>().Immobilize(false);
                }
                if (dialogueBox.GetDialogue().type == "choice" || dialogueBox.GetDialogue().type == "method") {
                    DoChoice(dialogueBox, player);
                } else {
                    dialogueBox.selectedChoice = 0;
                }
            } else {
                preventFirstInteract = false;
            }
        } else {
            preventFirstInteract = false;
        }
    }
}
