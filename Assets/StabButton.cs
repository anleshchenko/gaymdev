using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StabButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0.75f);
        if (!isPressed)
        {
            isPressed = true;
            StartCoroutine(StabDelay());
        }
    }
   
    public void OnPointerUp(PointerEventData eventData)
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1);     
    }

    IEnumerator StabDelay() {
        yield return new WaitForSeconds(0.6f);
        isPressed = false;
    }
}