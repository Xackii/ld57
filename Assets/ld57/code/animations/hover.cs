using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
public class hover : animation, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    private float scaleFactor = 1.2f;
    public string desc;
    public override void Init()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(desc != "")
        {
            g.ft.tooltip_status(true, desc);
        }
        if(transform == null) return;
        transform.DOScale(originalScale * scaleFactor, 0.3f).SetEase(Ease.OutBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        g.ft.tooltip_status(false, "");
        if(transform == null) return;
        transform.DOScale(originalScale, 0.3f).SetEase(Ease.InBack);
    }
}
