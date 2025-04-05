using UnityEngine;
using UnityEngine.EventSystems;
public class dragable : initializable, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {   
        begin_drag_handler(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        drag_handler(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        end_drag_handler(eventData);
    }

    public virtual void begin_drag_handler(PointerEventData eventData)
    {
        return;
    }

    public virtual void drag_handler(PointerEventData eventData)
    {
        return;
    }

    public virtual void end_drag_handler(PointerEventData eventData)
    {
        return;
    }
}
