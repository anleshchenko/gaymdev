using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject ButtonLvl;
    public GameObject ButtonBack;

    public void StartLevel()
    {
        SceneManager.LoadScene("Survival");
    }

    public void BackToGMMenu()
    {
        SceneManager.LoadScene("GameModeMenu");
    }
}
