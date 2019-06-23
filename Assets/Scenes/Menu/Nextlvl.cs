using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nextlvl : MonoBehaviour
{
   public void NextLvl()
    {
        SceneManager.LoadScene("2lvl"); 
    }
}
