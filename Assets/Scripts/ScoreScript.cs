using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public ZombieWave wave;

    private string text;
    private Text score;
    private int total;
    private int current = 0;

    private int record;

    void Start()
    {
        score = GetComponent<Text>();
        text = LanguageLoader.LoadLanguage(PlayerPrefs.GetString("lang")).score;
        total = wave.wavesNumber;
        record = PlayerPrefs.GetInt("record");
        UpdateScore();
    }

    void Update()
    {
        if (total > wave.wavesNumber)
        {
            total--;
            current++;
            UpdateScore();
            if (current - 1 > record)
                PlayerPrefs.SetInt("record", current - 1);
        }           
    }

    private void UpdateScore()
    {
        score.text = text + current;
    }
}
