using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlCompleted : MonoBehaviour
{
    public void Complete()
    {
        SceneManager.LoadScene("Levels");
    }    
}
