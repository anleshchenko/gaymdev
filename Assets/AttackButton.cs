using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool isPressed;

    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0.75f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
    }
}