using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{
    
    public void RepeatScene()
    {
        SceneManager.LoadScene("NewSurvival");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
