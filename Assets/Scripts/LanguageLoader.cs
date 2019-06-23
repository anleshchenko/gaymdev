using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LanguageLoader : MonoBehaviour
{  

    public static Language LoadLanguage(string lang)
    {
        string path = Application.streamingAssetsPath + "/Languages/" + lang + ".json";
        TextAsset file = Resources.Load("Languages/" + lang) as TextAsset;
        return JsonUtility.FromJson<Language>(file.ToString());
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
    public string loading;
    public string score;
    public string record;
}

public class Country
{
    public string Lang { get; set; }
    public Sprite Flag { get; set; }
}
