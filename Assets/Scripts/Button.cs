using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool isPressed;

    private Image img;

    private const float C = 1;
    private const float P = 0.8f;

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
        img.color = new Color(P, P, P, 255);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        img.color = new Color(C, C, C, 255);
    }
}
