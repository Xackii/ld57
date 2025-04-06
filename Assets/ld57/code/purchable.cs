using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class purchable : initializable, IPointerClickHandler
{
    public bool purched = false;

    public bool infinity = false;

    public int cost = 1;

    public virtual void on_buy()
    {
        g.money_change(-cost);
        g.upgrades_buyed.Add(this);
        purched = true;
        GetComponent<Image>().enabled = false;
        return;
    }

    public void try_buy()
    {
        if(g == null) g = FindAnyObjectByType<game_controller>();
        if(purched) return;
        if(g.money < cost) return;
        on_buy();
    }
    
    public virtual void when_selling_effect()
    {
        return;
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
