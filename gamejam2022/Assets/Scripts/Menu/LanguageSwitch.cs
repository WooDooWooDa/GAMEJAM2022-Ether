using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguageSwitch : Interactable
{
    [SerializeField] private TextMeshProUGUI languageText;
    [SerializeField] private TextMeshProUGUI selectionText;
    [SerializeField] private GameObject spriteEN;
    [SerializeField] private GameObject spriteFR;

    public override void Interact(GameObject player)
    {
        var lang = PlayerPrefs.GetString("language");
        var newLang = lang == "FR" ? "EN" : "FR";
        PlayerPrefs.SetString("language", newLang);
        ToggleText(newLang);
        ToggleSprite(newLang == "FR");
    }

    void Start()
    {
        var lang = PlayerPrefs.GetString("language");
        ToggleText(lang);
        ToggleSprite(lang == "FR");
    }

    private void ToggleText(string lang)
    {
        languageText.text = lang == "FR" ? "Langage : " : "Language : ";
        selectionText.text = lang;
    }

    private void ToggleSprite(bool fr)
    {
        spriteFR.SetActive(fr);
        spriteEN.SetActive(!fr);
    }
}
