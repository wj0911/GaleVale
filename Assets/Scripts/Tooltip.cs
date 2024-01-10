using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI tooltipText;
    public RectTransform tooltipBackground;
    public RectTransform tooltipBackgroundBackground;
    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;

    private void OnEnable() {
        OnMouseHover += ShowTooltip;
        OnMouseLoseFocus += HideTooltip;
    }
    private void OnDisable() {
        OnMouseHover -= ShowTooltip;
        OnMouseLoseFocus -= HideTooltip;
    }

    void Start() {
        HideTooltip();
    }
    private void ShowTooltip(string tooltipString, Vector2 mousePos) {
        tooltipText.text = tooltipString;
        tooltipBackground.sizeDelta = new Vector2(tooltipText.preferredWidth, tooltipText.preferredHeight);
        tooltipBackgroundBackground.sizeDelta = new Vector2(tooltipText.preferredWidth + 0.32f, tooltipText.preferredHeight + 0.32f);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        tooltipBackgroundBackground.gameObject.SetActive(true);
        tooltipBackgroundBackground.position = new Vector2(mousePos.x+tooltipBackground.sizeDelta.x/2, mousePos.y+tooltipBackground.sizeDelta.y/2);
        tooltipBackgroundBackground.transform.localPosition = new Vector3 (tooltipBackgroundBackground.transform.localPosition.x, tooltipBackgroundBackground.transform.localPosition.y, 0);
    }

    private void HideTooltip() {
        tooltipText.text = default;
        tooltipBackgroundBackground.gameObject.SetActive(false);
    }
}
