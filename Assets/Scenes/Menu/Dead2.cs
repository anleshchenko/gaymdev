using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dead2 : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Levels");
    }
}
