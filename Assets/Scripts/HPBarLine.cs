using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarLine : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] Slider slider;
    
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float health = player.health / 100;
        slider.value = health;
    }
}
