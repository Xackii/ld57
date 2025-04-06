using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class tutor_mascot : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI to_say;
    public tutor_manager manager;

    public void OnPointerClick(PointerEventData eventData)
    {
        manager.NextTip();
    }
    public void UpdateTip(string newTip)
    {
        to_say.text = newTip;
    }
}
