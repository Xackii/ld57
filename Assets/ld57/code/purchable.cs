using UnityEngine;
using UnityEngine.EventSystems;

public class purchable : initializable, IPointerClickHandler
{
    public bool purched = false;

    public int cost = 1;

    public virtual void on_buy()
    {
        g.money_change(-cost);
        g.upgrades_buyed.Add(this);
        return;
    }

    public void try_buy()
    {
        if(g == null) g = FindAnyObjectByType<game_controller>();
        if(g.money < cost) return;
        on_buy();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        try_buy();
    }

    public virtual void on_refund()
    {
        return;
    }
    
}
