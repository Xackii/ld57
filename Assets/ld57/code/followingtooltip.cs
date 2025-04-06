using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class followingtooltip : MonoBehaviour
{
    RectTransform rectTransform;
    Image tooltip_image;
    Canvas canvas;
    TextMeshProUGUI description_to_ui;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        tooltip_image = GetComponent<Image>();
        description_to_ui = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {   
        Vector2 mousePosition = Input.mousePosition;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.worldCamera, out localPoint);
        rectTransform.localPosition = localPoint;
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;
        if (mousePosition.y > screenHeight / 2)
        {
            rectTransform.anchorMin = new Vector2(0.5f, 0f); 
            rectTransform.anchorMax = new Vector2(0.5f, 0f); 
            rectTransform.pivot = new Vector2(0.5f, 1.1f);
        }
        else
        {
            rectTransform.anchorMin = new Vector2(0.5f, 1f); 
            rectTransform.anchorMax = new Vector2(0.5f, 1f); 
            rectTransform.pivot = new Vector2(0.5f, -0.01f);
        }
        if (mousePosition.x > screenWidth / 2)
        {
            rectTransform.anchorMin = new Vector2(0.5f, 0f); 
            rectTransform.anchorMax = new Vector2(0.5f, 0f); 
            rectTransform.pivot = new Vector2(1f, rectTransform.pivot.y);
        }
        else
        {
            rectTransform.anchorMin = new Vector2(0.5f, 1f); 
            rectTransform.anchorMax = new Vector2(0.5f, 1f); 
            rectTransform.pivot = new Vector2(0f, rectTransform.pivot.y);
        }
    }

    public void tooltip_status(bool set_tooltip, string set_desc)
    {
        description_to_ui.text = set_desc;
        if(tooltip_image == null) return;
        tooltip_image.enabled = set_tooltip;
        foreach(Image parent_image in GetComponentsInChildren<Image>())
        {
            parent_image.enabled = set_tooltip;
        }
        foreach(TextMeshProUGUI parent_text in GetComponentsInChildren<TextMeshProUGUI>())
        {
            parent_text.enabled = set_tooltip;
        }
        
    }

}
