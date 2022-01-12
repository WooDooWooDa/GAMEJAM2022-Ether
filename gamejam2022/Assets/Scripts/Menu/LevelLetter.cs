using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLetter : Interactable
{
    [SerializeField] private int levelToStart;

    public int GetLevel()
    {
        return levelToStart;
    }

    public override void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        if (!inventory.Contains("letter")) {
            gameObject.SetActive(false);
            inventory.Add("letter", gameObject);
        }
    }
}
