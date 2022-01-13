using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : Interactable
{
   [SerializeField] protected AudioSource _interactSound;

   protected void PlayInteractSound()
   {
      if (_interactSound != null)
      {
         _interactSound.Play();
      }
   }
}
