using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject ButtonPlay;
    public GameObject ButtonSettings;
    public GameObject ButtonExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
