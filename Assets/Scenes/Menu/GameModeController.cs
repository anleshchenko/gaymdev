using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModeController : MonoBehaviour
{
    public Text campaign;
    public Text survival;
    public Text loading;

    public GameObject loadingObject;

    void Start()
    {
        SetLanguage();
    }

    private void SetLanguage()
    {
        Language lang = LanguageLoader.LoadLanguage(PlayerPrefs.GetString("lang"));
        campaign.text = lang.campaign;
        survival.text = lang.survival;
        loading.text = lang.loading;
    }

    public void ShowCampaignMenu()
    {
        SceneManager.LoadScene("Levels");
    }

    public void ShowSurvivalMenu()
    {
        loadingObject.SetActive(true);
        SceneManager.LoadScene("NewSurvival");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
