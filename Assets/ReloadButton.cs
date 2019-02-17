using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public bool isPressed;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.75f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    }
}
