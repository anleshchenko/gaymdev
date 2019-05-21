using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarColor : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image image;

    void Start()
    {
    }

    void FixedUpdate()
    {
        float color = player.health / 100;
        image.color = new Color(1 - color, color, 0);
    }
}
