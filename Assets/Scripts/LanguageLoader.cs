using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LanguageLoader : MonoBehaviour
{  

    public static Language LoadLanguage(string lang)
    {
        string json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + lang + ".json");
        return JsonUtility.FromJson<Language>(json);
    }
}

public class Language
{
    public string play;
    public string settings;
    public string exit;
    public string campaign;
    public string survival;
    public string language;
    public string sound;
    public string music;
}

public class Country
{
    public string Lang { get; set; }
    public Sprite Flag { get; set; }
}
