using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : Interactable
{
    [SerializeField] private GameObject crowd;

    public override void Interact(GameObject player)
    {
        SoundTheAlarm();
    }

    private void SoundTheAlarm()
    {
        Debug.LogWarning("ALARME!!!");
        crowd.SetActive(false);
    }
}
