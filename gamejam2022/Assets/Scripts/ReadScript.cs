using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadScript : MonoBehaviour
{
    public TextAsset jsonFile;

    void Start()
    {
        AllNPC npcsJson = JsonUtility.FromJson<AllNPC>(jsonFile.text);

        foreach (NPC npc in npcsJson.npcs) {
            Debug.Log("Found employee: " + npc.name);
        }
    }
}
