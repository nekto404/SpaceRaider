using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public UnityEvent OnReleased;
    private bool relesed = false;

    void Update()
    {
        if (relesed)
            OnReleased.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        relesed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        relesed = true;
    }
}