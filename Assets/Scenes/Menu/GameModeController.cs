using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeController : MonoBehaviour
{
    public GameObject ButtonCampaign;
    public GameObject ButtonSurvival;
    public GameObject ButtonBack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
