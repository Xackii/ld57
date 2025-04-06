using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class wheel : dragable
{
    private RectTransform rectTransform;
    private float initialRotation;      
    private float currentRotation;      
    private float lastMouseX;           
    private bool isDragging = false;    
    public float sensitivity = 0.1f;      
    public float smoothing = 0.1f;        
    public override void Init()
    {
        base.Init();
        rectTransform = GetComponent<RectTransform>();
        initialRotation = rectTransform.rotation.eulerAngles.z;
        currentRotation = initialRotation; 
        lastMouseX = Input.mousePosition.x;
        
    }
    public override void drag_handler(PointerEventData eventData)
    {
        if(!isDragging)
            return;
        float mouseX = Input.mousePosition.x;
        float deltaX = lastMouseX - mouseX;
        float targetRotation = currentRotation + (deltaX * sensitivity);
        targetRotation = Mathf.Clamp(targetRotation, initialRotation - 90f, initialRotation + 90f);
        currentRotation = Mathf.Lerp(currentRotation, targetRotation, smoothing);
        rectTransform.rotation = Quaternion.Euler(0, 0, currentRotation);
        lastMouseX = mouseX;
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

        StartCoroutine(initial_pos());
    }

    private IEnumerator initial_pos()
    {
        float timeElapsed = 0f;
        float duration = 0.5f;
        float startRotation = currentRotation;

        while (timeElapsed < duration)
        {
            currentRotation = Mathf.Lerp(startRotation, initialRotation, timeElapsed / duration);
            rectTransform.rotation = Quaternion.Euler(0, 0, currentRotation);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        currentRotation = initialRotation;
        rectTransform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }

    public float get_angel()
    {
        return currentRotation - initialRotation;
    }
}
