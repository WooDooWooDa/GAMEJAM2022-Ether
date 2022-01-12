using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLetter : Interactable
{
    [SerializeField] private int levelToStart;

    public override void Interact()
    {
        Debug.Log("Interac with letter of level " + levelToStart);
    }
}
