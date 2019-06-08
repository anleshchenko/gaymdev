using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Image flag;

    public Sprite us; 
    public Sprite ukr;
    public Sprite rus;

    public Text settings;
    public Text language;
    public Text sound;
    public Text music;

    private string lang;

    void Start()
    {
        SetLanguage();  
    }

    private void SetLanguage()
    {
        lang = PlayerPrefs.GetString("lang");
        Language languageObj = LanguageLoader.LoadLanguage(lang);
        settings.text = languageObj.settings;
        language.text = languageObj.language;
        sound.text = languageObj.sound;
        music.text = languageObj.music;
        if (lang == "uk_UA")
            flag.sprite = ukr;
        if (lang == "ru_RU")
            flag.sprite = rus;
    }


    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SwitchLanguage()
    {
        if (lang == "en_US")
        {
            PlayerPrefs.SetString("lang", "uk_UA");
            flag.sprite = ukr;
        }
        if (lang == "uk_UA")
        {
            PlayerPrefs.SetString("lang", "ru_RU");
            flag.sprite = rus;
        }
        if (lang == "ru_RU")
        {
            PlayerPrefs.SetString("lang", "en_US");
            flag.sprite = us;
        }
        SetLanguage();
    }

    private void SetLanguage(int lang)
    {

    }
}
