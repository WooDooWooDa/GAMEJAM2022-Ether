using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadScript : MonoBehaviour
{
    public TextAsset jsonFileFR;
    public TextAsset jsonFileEN;
    
    private static readonly List<string> MaleNames = new List<string>()
    {
        "Tyler", "Axel" , "Arthur" , "Evan" , "Adrien" , "Alexis" , "Antoine" , "Adam" , "Alexandre" , "Tyler", "Baptiste" , "Enzo" , "Julien" , "Leo" , "Lucas" , "Matteo" , "Mael" , "Maxime" , "Gabriel" , "Raphael" , "Pierre" , "Quentin" , "Hugo" , "Romain" , "Theo" , "Tom" , "Jules" , "Nicolas" , "Louis" , "Mathis" , "Nathan" , "Paul" , "Valentin" , "Ethan" , "Tyler", "Kylian" , "Matheo" , "Aaron" , "Antonin" , "Anthony" , "Ayoub" , "Bastien" , "Alan" , "Aymeric" , "Bryan" , "Charles" , "Elias" , "Dorian" , "Dylan" , "Alex" , "Augustin" , "Alban" , "Aurelien" , "Benjamin" , "Arnaud" , "Gael" , "Gabin" , "Guillaume" , "Florian" , "Corentin" , "Jean" , "Jeremy" , "Diego" , "Emilien" , "Esteban" , "David" , "Etienne" , "Damien" , "Erwan" , "Lukas" , "Loic" , "Lorenzo" , "Mathias" , "Matthieu" , "Gaetan" , "Gaspard" , "Morgan" , "Rafael" , "Kilian" , "Samuel" , "Simon" , "Kevin" , "Sacha" , "Tristan" , "Victor" , "Jordan" , "Killian" , "Marius" , "Vincent" , "Martin" , "Yann" , "Mateo" , "William" , "Luca" , "Remi" , "Oscar" , "Robin" , "Noe" , "Tony" , "Tiago" , "Thibaut" , "Bilal" , "Thibault" , "Eliot" , "Elouan" , "Ilan" , "Eliott" , "Julian" , "Kyllian" , "Ewan" , "Luka"
    };
    private static readonly List<string> FemaleNames = new List<string>()
    {
        "Camille", "Anais", "Clara", "Emma", "Charlotte", "Celia", "Eva", "Ambre", "Clemence", "Juliette", "Lena", "Lea", "Jeanne", "Julie", "Maeva", "Mathilde", "Louise", "Lucie", "Manon", "Noemie", "Jade", "Ines", "Sarah", "Laura", "Lola", "Oceane", "Pauline", "Romane", "Zoe", "Lina", "Lisa", "Maëlys", "Alicia", "Andrea", "Audrey", "Angele", "Adele", "Alexia", "Amandine", "Angelina", "Chiara", "Claire", "Coralie", "Elsa", "Agathe", "Constance", "Eleonore", "Elisa", "Elodie", "Fanny", "Alice", "Anna", "Apolline", "Candice", "Charline", "Elise", "Emilie", "Amelie", "Axelle", "Capucine", "Flavie", "Heloise", "Emeline", "Eloise", "Leonie", "Carla", "Cassandra", "Clarisse", "Elina", "Clementine", "Elena", "Marion", "Melina", "Marine", "Melissa", "Lise", "Mailys", "Melanie", "Flora", "Gabrielle", "Ninon", "Rose", "Salome", "Julia", "Lana", "Valentine", "Sofia", "Justine", "Myriam", "Maelle", "Maud", "Yasmine", "Lucile", "Maya", "Olivia", "Nina", "Sara", "Chaima", "Solene", "Clea", "Victoire", "Victoria", "Assia", "Elea", "Anaelle", "Alyssa", "Ilona", "Aya"
    };

    private static readonly List<int> FemaleSpriteIndices = new List<int>() { 1, 2, 6, 10 };

    public string GetNpcDisplayName(string npcName, int spriteIndex)
    {
        var loweredCaseNpcName = npcName.ToLower();
        if (loweredCaseNpcName == "habitant" || loweredCaseNpcName == "foule" || loweredCaseNpcName == "visiteur") {
            var displayName = FemaleSpriteIndices.Contains(spriteIndex) ? FemaleNames[UnityEngine.Random.Range(0, FemaleNames.Count - 1)] : MaleNames[UnityEngine.Random.Range(0, MaleNames.Count - 1)];
            return displayName ?? npcName;
        }
        return npcName;
    }

    public NPC[] ReadNpcs()
    {
        return JsonUtility.FromJson<AllNPC>(GetFile().text).npcs;
    }

    public enum Gender
    {
        Male,
        Female
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
