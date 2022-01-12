using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadScript : MonoBehaviour
{
    public TextAsset jsonFileFR;
    public TextAsset jsonFileEN;

    public NPC[] ReadNpcs()
    {
        return JsonUtility.FromJson<AllNPC>(GetFile().text).npcs;
    }

    public NPC GetNpc(string npcName)
    {
        NPC[] npcs = JsonUtility.FromJson<AllNPC>(GetFile().text).npcs;
        foreach (NPC npc in npcs) {
            if (npc.name == npcName)
                return npc;
        }
        return null;
    }

    private TextAsset GetFile()
    {
        return PlayerPrefs.GetString("language", "FR") == "FR" ? jsonFileFR : jsonFileEN;
    }
}
