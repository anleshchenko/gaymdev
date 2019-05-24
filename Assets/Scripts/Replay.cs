using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReplayDelay());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReplayDelay()
    {   
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
    }
}
