using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public Text play;
    public Text settings;
    public Text exit;

    void Start()
    {
        ChooseLang();
        SetLanguage();
    }

    private void ChooseLang()
    {
        if (!PlayerPrefs.HasKey("lang"))
        {
            if (Application.systemLanguage == SystemLanguage.Ukrainian)
                PlayerPrefs.SetString("lang", "uk_UA");
            else if (Application.systemLanguage == SystemLanguage.Russian)
                PlayerPrefs.SetString("lang", "ru_RU");
            else
                PlayerPrefs.SetString("lang", "en_US");
        }
    }

    private void SetLanguage()
    {
        Language lang = LanguageLoader.LoadLanguage(PlayerPrefs.GetString("lang"));
        play.text = lang.play;
        settings.text = lang.settings;
        exit.text = lang.exit;
    }

    public void ShowSettingsMenu()
    {
        
        SceneManager.LoadScene ("SettingsMenu");

    }
    public void ShowPlayMenu()
    {
         
        SceneManager.LoadScene("GameModeMenu"); 

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
