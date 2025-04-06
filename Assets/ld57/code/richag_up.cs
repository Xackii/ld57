using UnityEngine;
using UnityEngine.EventSystems;

public class richag_up : dragable
{
    public GameObject upw;
    public GameObject downw;
    bool isDragging = false;
    private float minY;
    private float maxY;
    private RectTransform rectTransform;
    public float smoothSpeed = 5f; 

    public override void Init()
    {
        base.Init();
        rectTransform = GetComponent<RectTransform>();
        minY = downw.GetComponent<RectTransform>().localPosition.y;
        maxY = upw.GetComponent<RectTransform>().localPosition.y;
    }

    public override void drag_handler(PointerEventData eventData)
    {
        if (!isDragging)
            return;
        Vector2 globalPointerPosition = eventData.position;
        Vector2 localPointerPosition = rectTransform.InverseTransformPoint(globalPointerPosition);
        float targetY = rectTransform.localPosition.y;

        if (localPointerPosition.y > rectTransform.localPosition.y)
        {
            targetY = Mathf.Lerp(rectTransform.localPosition.y, maxY, Time.deltaTime * smoothSpeed);
        }
        else if (localPointerPosition.y < rectTransform.localPosition.y)
        {
            targetY = Mathf.Lerp(rectTransform.localPosition.y, minY, Time.deltaTime * smoothSpeed);
        }

        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, targetY, rectTransform.localPosition.z);

        if (Mathf.Abs(targetY - minY) < 0.01f)
        {
            if (!isAtMin)
            {
                isAtMin = true;
                g.sc.change_move_dir(false);
            }
        }
        else if (Mathf.Abs(targetY - maxY) < 0.01f)
        {
            if (!isAtMax)
            {
                isAtMax = true;
                g.sc.change_move_dir(true);
            }
        }
        else
        {
            isAtMin = isAtMax = false;
        }
    }

    public override void begin_drag_handler(PointerEventData eventData)
    {
        base.begin_drag_handler(eventData);
        isDragging = true;
    }

    public override void end_drag_handler(PointerEventData eventData)
    {
        base.end_drag_handler(eventData);
        isDragging = false;
    }

    private bool isAtMin = false;
    private bool isAtMax = false;
}
