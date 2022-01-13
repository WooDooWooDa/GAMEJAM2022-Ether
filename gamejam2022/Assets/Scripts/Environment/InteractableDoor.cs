using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractableDoor : Interactable
{
    [SerializeField] private AudioSource _knockSounds;
    [SerializeField] private AudioSource _openSound;
    [SerializeField] private Coordinate _destinationCoordinates;
    [SerializeField] private bool _canOpen;

    private void Knock()
    {
        _knockSounds.Play();
    }
    
    private void Open(GameObject player)
    {
        _openSound.Play();
        Teleport(_destinationCoordinates, player);
    }

    private void Teleport(Coordinate coordinate, GameObject player)
    {
        Vector2 newPosition = new Vector2(coordinate.xCoordinate, coordinate.yCoordinate);
        player.gameObject.transform.position = newPosition;
    }

    public override void Interact(GameObject player)
    {
        if (_canOpen) {
            Open(player);
        } else {
            Knock();
        }
    }
}
