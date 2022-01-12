using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject choicesText;
    [SerializeField] private GameObject choiceArrow;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private GameObject angryBubble;

    private Dialogue dialogue;
    public float selectedChoice = 1;

    private void Update()
    {
        if (dialogue.type == "choice" && Input.GetAxisRaw("Horizontal") != 0) {
            selectedChoice = Input.GetAxisRaw("Horizontal");
            choiceArrow.transform.localPosition = new Vector3(selectedChoice < 0 ? -1.2f : -0.2f, 0.115f, 0);
        }
    }

    public Dialogue GetDialogue()
    {
        return dialogue;
    }

    public void ToggleBubble()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public IEnumerator IsAngry()
    {
        angryBubble.SetActive(!angryBubble.activeSelf);
        yield return new WaitForSeconds(2f);
        angryBubble.SetActive(!angryBubble.activeSelf);
    }

    public void SetName(string npcName)
    {
        nameText.text = npcName;
    }
    public void Set(Dialogue dialogue)
    {
        this.dialogue = dialogue;
        dialogueText.text = dialogue.sentence;
        ShowChoices(dialogue.type == "choice");
    }

    private void ShowChoices(bool val)
    {
        choicesText.SetActive(val);
        if (!val)
            return;
        TextMeshProUGUI[] texts = choicesText.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = dialogue.choices[0];
        texts[1].text = dialogue.choices[1];
    }
}