using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hoverable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tooltipText;
    public bool hovered;
    public void OnPointerEnter(PointerEventData eventData) {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        hovered = false;
        Tooltip.OnMouseLoseFocus();
    }

    private void OnDisable() {
        hovered = false;
        Tooltip.OnMouseLoseFocus();
    }

    void Update() {
        if (hovered) {
            Tooltip.OnMouseHover(tooltipText, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0)));
        }
    }
}
