using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour
{
    void Start()
    {
        Text text = GetComponent<Text>();
        string s = LanguageLoader.LoadLanguage(PlayerPrefs.GetString("lang")).record;
        text.text = s + PlayerPrefs.GetInt("record");
    }
}
