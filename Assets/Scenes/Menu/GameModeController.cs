﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeController : MonoBehaviour
{
    public Text campaign;
    public Text survival;

    void Start()
    {
        SetLanguage();
    }

    private void SetLanguage()
    {
        Language lang = LanguageLoader.LoadLanguage(PlayerPrefs.GetString("lang"));
        campaign.text = lang.campaign;
        survival.text = lang.survival;
    }

    public void ShowCampaignMenu()
    {

    }
    public void ShowSurvivalMenu()
    {
        SceneManager.LoadScene("Survival");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
