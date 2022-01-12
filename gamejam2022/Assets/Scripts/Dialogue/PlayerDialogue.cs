using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
	[SerializeField] GameObject _dialogue;

    void Update()
    {
		ShowDialogue();
		ChangeDialogue();
	}

	private void InteractWithMenu()
	{
		
	}

	private void ChangeDialogue()
	{
		if (!Input.GetKeyDown(KeyCode.F)) return;
		if (_dialogue.activeSelf) {
			_dialogue.GetComponentInChildren<DialogueScript>().SetDialogueText("test 1 2 test");
		}
	}

	private void ShowDialogue()
	{
		if (!Input.GetKeyDown(KeyCode.R)) return;
		_dialogue.gameObject.SetActive(!_dialogue.gameObject.activeSelf);
		//TogglePlayerMovement();
	}
}
