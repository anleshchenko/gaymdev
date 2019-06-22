using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Image flagImage;
    public Image soundImage;
    public Image musicImage;

    public Sprite us;
    public Sprite ukr;
    public Sprite rus;

    public Sprite musicOff;
    public Sprite musicOn;

    public Sprite soundOff;
    public Sprite soundOn;

    public Text settings;
    public Text language;
    public Text sound;
    public Text music;

    private string lang;

    void Start()
    {
        SetLanguage();
        SetSound();
        SetMusic();        
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
            flagImage.sprite = ukr;
        if (lang == "ru_RU")
            flagImage.sprite = rus;
    }

    private void SetMusic()
    {
        if (PlayerPrefs.GetInt("music") != 0)
            musicImage.sprite = musicOn;
        else
            musicImage.sprite = musicOff;
    }

    private void SetSound()
    {
        if (PlayerPrefs.GetInt("sound") != 0)
            soundImage.sprite = soundOn;
        else
            soundImage.sprite = soundOff;
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
            flagImage.sprite = ukr;
        }
        if (lang == "uk_UA")
        {
            PlayerPrefs.SetString("lang", "ru_RU");
            flagImage.sprite = rus;
        }
        if (lang == "ru_RU")
        {
            PlayerPrefs.SetString("lang", "en_US");
            flagImage.sprite = us;
        }
        PlayerPrefs.Save();
        SetLanguage();
    }

    public void SwitchMusic()
    {
        if (PlayerPrefs.GetInt("music") == 0)
        {
            PlayerPrefs.SetInt("music", 1);
            musicImage.sprite = musicOn;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            musicImage.sprite = musicOff;
        }
    }

    public void SwitchSound()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            PlayerPrefs.SetInt("sound", 1);
            soundImage.sprite = soundOn;
        }
        else
        {
            PlayerPrefs.SetInt("sound", 0);
            soundImage.sprite = soundOff;
        }
    }
}
