using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;
    CanvasGroup canvas;

    void Start()
    {
        canvas = FindObjectOfType<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        canvas.alpha = 0;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        canvas.alpha = 1;
    }

}
